var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("sql").AddDatabase("db");

var myService = builder.AddProject<Projects.Api>("api")
                       .WithReference(db)
                       .WaitFor(db);

builder.Build().Run();
