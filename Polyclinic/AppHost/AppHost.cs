var builder = DistributedApplication.CreateBuilder(args);

var kafkaTopic = builder.AddParameter("KafkaTopic", "visit-events");
var producerIntervalMs = builder.AddParameter("KafkaProducerIntervalMs", "5000");
var producerBatchSize = builder.AddParameter("KafkaProducerBatchSize", "1");
var consumerGroup = builder.AddParameter("KafkaConsumerGroup", "polyclinic-api-visit-consumer");

var sqlServer = builder.AddSqlServer("sqlserver");
var sqlDb = sqlServer.AddDatabase("PolyclinicDb");

var kafka = builder.AddKafka("kafka")
       .WithKafkaUI();

builder.AddProject<Projects.Api>("api")
       .WithReference(sqlDb, "DefaultConnection") 
       .WithReference(kafka, "KafkaConnection")   
       .WithEnvironment("KafkaTopic", kafkaTopic)
       .WithEnvironment("Kafka_ConsumerGroup", consumerGroup)
       .WaitFor(sqlDb)
       .WaitFor(kafka); 

builder.AddProject<Projects.Generator>("generator")
       .WithReference(kafka, "KafkaConnection")
       .WithEnvironment("KafkaTopic", kafkaTopic)
       .WithEnvironment("KafkaProducerIntervalMs", producerIntervalMs)
       .WithEnvironment("KafkaProducerBatchSize", producerBatchSize)
       .WaitFor(kafka); 

builder.Build().Run();