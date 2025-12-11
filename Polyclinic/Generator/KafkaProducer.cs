using System.Text.Json;
using Aspire.Confluent.Kafka;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace Generator;

/// <summary>
/// Background service that generates fake visit events and publishes them to a Kafka topic.
/// </summary>
public class KafkaProducer(
    IOptions<GeneratorOptions> settings,
    IProducer<Null, string> producer,
    ILogger<KafkaProducer> logger
) : BackgroundService
{
    /// <summary>
    /// Continuously generates and publishes visit events to Kafka at configured intervals.
    /// </summary>
    /// <param name="stopToken">Cancellation token to stop the producer gracefully.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    protected override async Task ExecuteAsync(CancellationToken stopToken)
    {
        logger.LogInformation(
            "KafkaProducer started with IntervalMs={IntervalMs}, BatchSize={BatchSize}, Topic={Topic}",
             settings.Value.IntervalMs,
             settings.Value.BatchSize,
             settings.Value.Topic);

        while (!stopToken.IsCancellationRequested)
        {
            try
            {
                for (var i = 0; i < settings.Value.BatchSize; ++i)
                {
                    var dto = Generator.GenerateLinks(1).First();
                    var json = JsonSerializer.Serialize(dto);

                    logger.LogInformation("Generating visit event {msg}", json);

                    await producer.ProduceAsync(
                        settings.Value.Topic,
                        new Message<Null, string> { Value = json },
                        stopToken);
                }

                await Task.Delay(settings.Value.IntervalMs, stopToken);
            }
            catch (OperationCanceledException)
            {
                logger.LogInformation("KafkaProducer received cancellation request");
                break;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "KafkaProducer failed to produce message to Kafka topic");
            }
        }

        logger.LogInformation("KafkaProducer stopped");
    }
}