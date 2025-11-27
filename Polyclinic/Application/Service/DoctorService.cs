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
    private static Doctor MapToDomain(DoctorDto entity)
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
    /// Maps Doctor entity to DoctorDto
    /// </summary>
    /// <param name="doctor">Doctor entity</param>
    /// <returns>Mapped Doctor DTO</returns>
    private static DoctorDto MapToDto(Doctor doctor)
    {
        return new DoctorDto
        {
            Passport = doctor.Passport,
            Name = doctor.Name,
            Birthday = doctor.Birthday,
            Specialization = doctor.Specialization,
            WorkExperience = doctor.WorkExperience,
        };
    }

    /// <summary>
    /// Creates a new doctor from DTO data
    /// </summary>
    /// <param name="entity">Doctor data transfer object</param>
    /// <returns>ID of the created doctor</returns>
    public async Task<int> CreateDoctorAsync(DoctorDto entity)
    {
        return await doctorRepository.CreateAsync(MapToDomain(entity));
    }

    /// <summary>
    /// Retrieves all doctors from the repository as DTOs
    /// </summary>
    /// <returns>List of all doctors as DTOs</returns>
    public async Task<List<DoctorDto>> GetAllDoctorsAsync()
    {
        var doctors = await doctorRepository.ReadAsync();
        return [.. doctors.Select(MapToDto)];
    }

    /// <summary>
    /// Gets doctors with work experience greater than or equal to target as DTOs
    /// </summary>
    /// <param name="targetWorkExperience">Minimum work experience in years</param>
    /// <returns>List of filtered doctors as DTOs</returns>
    public async Task<List<DoctorDto>> GetAllWithWorkExperienceMoreTargetAsync(int targetWorkExperience)
    {
        var doctors = await doctorRepository.ReadAsync();
        return [.. doctors
            .Where(d => d.WorkExperience >= targetWorkExperience)
            .Select(MapToDto)];
    }

    /// <summary>
    /// Retrieves a specific doctor by ID as DTO
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>Doctor DTO or null if not found</returns>
    public async Task<DoctorDto?> GetDoctorAsync(int id)
    {
        var doctor = await doctorRepository.ReadAsync(id);
        return doctor != null ? MapToDto(doctor) : null;
    }

    /// <summary>
    /// Updates an existing doctor's information
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <param name="entity">Updated doctor data</param>
    /// <returns>Updated doctor DTO or null if not found</returns>
    public async Task<DoctorDto?> UpdateDoctorAsync(int id, DoctorDto entity)
    {
        var doctorToUpdate = MapToDomain(entity);

        var updatedDoctor = await doctorRepository.UpdateAsync(id, doctorToUpdate);
        return updatedDoctor != null ? MapToDto(updatedDoctor) : null;
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

    /// <summary>
    /// Retrieves all doctors from the repository as Domain class.
    /// </summary>
    /// <returns>List of all doctors as DTOs</returns>
    public async Task<List<Doctor>> GetAllDoctorsWithIdAsync()
    {
        return await doctorRepository.ReadAsync();
    }
}