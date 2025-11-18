using Infrastructure.InMemory.Seeders;
using Infrastructure.InMemory.Repositories;
using Domain.Repositories;
using Application.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InMemoryPatientRepositorySeeder>();
builder.Services.AddSingleton<IPatientRepository, InMemoryPatientRepository>();
builder.Services.AddSingleton<PatientService>();

builder.Services.AddSingleton<InMemoryDoctorRepositorySeeder>();
builder.Services.AddSingleton<IDoctorRepository, InMemoryDoctorRepository>();
builder.Services.AddSingleton<DoctorService>();

builder.Services.AddSingleton<InMemoryVisitRepositorySeeder>();
builder.Services.AddSingleton<IVisitRepository, InMemoryVisitRepository>();
builder.Services.AddSingleton<VisitService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
