using ServiceDefaults;
using Confluent.Kafka;
using Generator;
using Aspire.Confluent.Kafka;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.Configure<KafkaProducerSettings>(builder.Configuration.GetSection("KafkaProducer"));

var kafkaConnection = builder.Configuration.GetConnectionString("KafkaConnection") ?? throw new InvalidOperationException("Kafka connection string is not configured."); ;

builder.Services.AddSingleton(s =>
{
    var config = new ProducerConfig
    {
        BootstrapServers = kafkaConnection,
        Acks = Acks.All,
        EnableIdempotence = true
    };
    return new ProducerBuilder<Null, string>(config).Build();
});

builder.Services.AddHostedService<KafkaProducer>();

var host = builder.Build();
host.Run();
