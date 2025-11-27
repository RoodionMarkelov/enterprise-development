var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("sql").AddDatabase("db");

builder.AddProject<Projects.Api>("api")
                       .WithReference(db)
                       .WaitFor(db);

builder.Build().Run();
