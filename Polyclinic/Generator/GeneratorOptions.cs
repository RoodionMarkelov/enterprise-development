namespace Generator;

/// <summary>
/// Configuration options for Kafka message generation.
/// </summary>
public class GeneratorOptions
{
    /// <summary>
    /// Delay between batches in seconds.
    /// </summary>
    public int IntervalMs { get; set; } = 5000;

    /// <summary>
    /// Number of messages to send per batch.
    /// </summary>
    public int BatchSize { get; set; } = 1;


    /// <summary>
    /// Kafka topic name where visit events will be published.
    /// </summary>
    public string Topic { get; set; } = "visit-events";
}

