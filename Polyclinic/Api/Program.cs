using Domain.Repositories;
using Application.Service;
using Infrastructure.Db;
using Infrastructure.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using ServiceDefaults;

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

builder.Services.AddScoped<IDoctorRepository, DbDoctorRepository>();
builder.Services.AddScoped<IPatientRepository, DbPatientRepository>();
builder.Services.AddScoped<IVisitRepository, DbVisitRepository>();

builder.Services.AddScoped<DoctorService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<VisitService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;

    options.IncludeXmlComments(Path.Combine(basePath,"Api.xml"));
    options.IncludeXmlComments(Path.Combine(basePath,"Domain.xml"));
    options.IncludeXmlComments(Path.Combine(basePath,"Application.xml"));
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
app.MapControllers();

app.Run();