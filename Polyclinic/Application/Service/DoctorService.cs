using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

/// <summary>
/// Service for managing doctor operations including creation, retrieval, updating, and deletion
/// </summary>
/// <param name="doctorRepository">Doctor repository instance</param>
public class DoctorService(IRepository<Doctor> doctorRepository) : IDoctorService
{
    /// <summary>
    /// Maps DoctorDto to Doctor entity with default ID
    /// </summary>
    /// <param name="entity">Doctor data transfer object</param>
    /// <returns>Mapped Doctor entity</returns>
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
    /// <param name="entity">Doctor data transfer object</param>
    /// <returns>ID of the created doctor</returns>
    public async Task<int> CreateDoctorAsync(DoctorDto entity)
    {
        return await doctorRepository.CreateAsync(MapDto(entity));
    }

    /// <summary>
    /// Retrieves all doctors from the repository
    /// </summary>
    /// <returns>List of all doctors</returns>
    public async Task<List<Doctor>> GetAllDoctorsAsync()
    {
        return await doctorRepository.ReadAsync();
    }

    /// <summary>
    /// Gets doctors with work experience greater than or equal to target
    /// </summary>
    /// <param name="targetWorkExperience">Minimum work experience in years</param>
    /// <returns>List of filtered doctors</returns>
    public async Task<List<Doctor>> GetAllWithWorkExperienceMoreTargetAsync(int targetWorkExperience)
    {
        var doctors = await doctorRepository.ReadAsync();
        return doctors.Where(d => d.WorkExperience >= targetWorkExperience).ToList();
    }

    /// <summary>
    /// Retrieves a specific doctor by ID
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>Doctor entity or null if not found</returns>
    public async Task<Doctor?> GetDoctorAsync(int id)
    {
        return await doctorRepository.ReadAsync(id);
    }

    /// <summary>
    /// Updates an existing doctor's information
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <param name="entity">Updated doctor data</param>
    /// <returns>Updated doctor entity or null if not found</returns>
    public async Task<Doctor?> UpdateDoctorAsync(int id, Doctor entity)
    {
        return await doctorRepository.UpdateAsync(id, entity);
    }

    /// <summary>
    /// Deletes a doctor by ID
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeleteDoctorAsync(int id)
    {
        return await doctorRepository.DeleteAsync(id);
    }
}