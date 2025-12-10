using Confluent.Kafka;
using Application.DTO;
using Application.Service;
using System.Text.Json;

namespace Api.Kafka;

/// <summary>
/// Background service that consumes visit events from Kafka and persists them to the database.
/// </summary>
public class KafkaConsumer(
    IConfiguration configuration,
    IConsumer<Ignore, string> consumer,
    IServiceScopeFactory serviceScopeFactory,
    ILogger<KafkaConsumer> logger) : BackgroundService
{
    private readonly string _topic = configuration["KafkaTopic"] ?? "visit-events";

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// Main execution loop that continuously consumes Kafka messages and processes visit events.
    /// </summary>
    /// <param name="stopToken">Cancellation token to stop the consumer gracefully.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task ExecuteAsync(CancellationToken stopToken)
    {
        consumer.Subscribe(_topic);
        logger.LogInformation("KafkaVisitConsumer is starting. Subscribing to topic: {Topic}", _topic);

        while (!stopToken.IsCancellationRequested)
        {
            try
            {
                var consumeResult = consumer.Consume(stopToken);

                if (string.IsNullOrEmpty(consumeResult?.Message?.Value))
                {
                    logger.LogWarning("An empty message was received");
                    continue;
                }

                var offset = consumeResult.TopicPartitionOffset;
                logger.LogDebug("Processing message at {Offset}", offset);

                var visitDto = JsonSerializer.Deserialize<VisitDto>(
                    consumeResult.Message.Value,
                    _jsonSerializerOptions);

                if (visitDto == null)
                {
                    logger.LogWarning("Skipped invalid message at {Offset}: unable to deserialize", offset);
                    continue;
                }

                using var scope = serviceScopeFactory.CreateScope();

                var visitService = scope.ServiceProvider.GetRequiredService<IVisitService>();

                var visitId = await visitService.CreateVisitAsync(visitDto);

                logger.LogInformation(
                    "Persisted visit ID={VisitId} for PatientId={PatientId} with DoctorId={DoctorId} at {Date}",
                    visitId, visitDto.PatientId, visitDto.DoctorId, visitDto.DateOfVisit);

                consumer.Commit(consumeResult);
            }
            catch (ConsumeException ex)
            {
                logger.LogError(ex, "Kafka consumption failed");
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error during message processing: {Message}", ex.Message);
            }
        }

        consumer.Close();
        logger.LogInformation("Kafka consumer stopped");
    }
}