using Domain.Repositories;
using Application.Service;
using Infrastructure.Db;
using Infrastructure.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using ServiceDefaults;
using Domain;
using Api.Kafka;
using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
    ));

builder.Services.AddScoped<IRepository<Doctor>, DbDoctorRepository>();
builder.Services.AddScoped<IRepository<Patient>, DbPatientRepository>();
builder.Services.AddScoped<IRepository<Visit>, DbVisitRepository>();

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IVisitService, VisitService>();

var kafkaConnection = builder.Configuration.GetConnectionString("KafkaConnection")
    ?? builder.Configuration["Kafka:BootstrapServers"]
    ?? throw new InvalidOperationException("Kafka connection is not configured");

var consumerGroup = builder.Configuration["Kafka:ConsumerGroup"]
    ?? "polyclinic-api-visit-consumer";

builder.Services.AddSingleton(sp =>
{
    var config = new ConsumerConfig
    {
        BootstrapServers = kafkaConnection,
        GroupId = consumerGroup,
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = false
    };
    return new ConsumerBuilder<Ignore, string>(config).Build();
});

builder.Services.AddHostedService<KafkaConsumer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    options.IncludeXmlComments(Path.Combine(basePath,"Api.xml"));
    options.IncludeXmlComments(Path.Combine(basePath,"Domain.xml"));
    options.IncludeXmlComments(Path.Combine(basePath,"Application.xml"));
});

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(allowedOrigins!)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();