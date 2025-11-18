using Application.DTO;
using Domain;
using Domain.Repositories;
using System.Numerics;

namespace Application.Service;

/// <summary>
/// Service for managing doctor operations including creation, retrieval, updating, and deletion
/// </summary>
/// <param name="repository"></param>
public class DoctorService(IDoctorRepository repository)
{
    /// <summary>
    /// Maps DoctorDto to Doctor entity with default ID
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Creates a new doctor from DTO data
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public int CreateDoctor(DoctorDto entity)
    {
        return repository.Create(MapDto(entity));
    }

    /// <summary>
    /// Retrieves all doctors from the repository
    /// </summary>
    /// <returns></returns>
    public List<Doctor> GetAllDoctors()
    {
        return repository.Read();
    }

    /// <summary>
    /// Gets doctors with work experience greater than or equal to target
    /// </summary>
    /// <param name="targetWorkExperience"></param>
    /// <returns></returns>
    public List<Doctor> GetAllWhithWorkExperienceMoreTarget(int targetWorkExperience)
    {
        return repository.Read()
           .Where(d => d.WorkExperience >= targetWorkExperience)
           .ToList();
    }

    /// <summary>
    /// Retrieves a specific doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Doctor? GetDoctor(int id)
    {
        return repository.Read(id);
    }

    /// <summary>
    /// Updates an existing doctor's information
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Doctor? UpdateDoctor(int id, Doctor entity)
    {
        return repository.Update(id, entity);
    }

    /// <summary>
    /// Deletes a doctor by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteDoctor(int id)
    {
        return repository.Delete(id);
    }
}