using Application.DTO;
using Domain;
using Domain.Repositories;
using System.Numerics;

namespace Application.Service;

public class DoctorService(IDoctorRepository repository)
{
    private static Doctor MapDto(DoctorDto entity)
    {
        return new Doctor
        {
            Id = 0,
            Passport = entity.Passport,
            Name = entity.Name,
            Birthday = entity.Birthday,
            Specialization = entity.Specialization,
            WorkExperience = entity.WorkExperience,
        };

    }

    public int CreatePatinet(DoctorDto entity)
    {
        return repository.Create(MapDto(entity));
    }

    public List<Doctor> GetAll()
    {
        return repository.Read().ToList();
    }

    public List<Doctor> GetAllWhithWorkExperienceMoreTarget(int targetWorkExperience)
    {
        return repository.Read()
           .Where(d => d.WorkExperience >= targetWorkExperience)
           .ToList();
    }

}

