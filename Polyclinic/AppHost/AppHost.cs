var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("sql").AddDatabase("db");

var myService = builder.AddProject<Projects.Api>("api") // без неё в докере не поднимется swagger
                       .WithReference(db)
                       .WaitFor(db);

builder.Build().Run();
