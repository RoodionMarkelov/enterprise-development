using Application.DTO;
using Domain;

namespace Application.Service;

/// <summary>
/// Service interface for doctor management operations
/// </summary>
public interface IDoctorService
{
    /// <summary>
    /// Creates a new doctor from DTO data
    /// </summary>
    /// <param name="entity">Doctor data transfer object</param>
    /// <returns>ID of the created doctor</returns>
    public Task<int> CreateDoctorAsync(DoctorDto entity);

    /// <summary>
    /// Retrieves all doctors from the repository as DTOs
    /// </summary>
    /// <returns>List of all doctors as DTOs</returns>
    public Task<List<DoctorResponseDto>> GetAllDoctorsAsync();

    /// <summary>
    /// Gets doctors with work experience greater than or equal to target as DTOs
    /// </summary>
    /// <param name="targetWorkExperience">Minimum work experience in years</param>
    /// <returns>List of filtered doctors as DTOs</returns>
    public Task<List<DoctorDto>> GetAllWithWorkExperienceMoreTargetAsync(int targetWorkExperience);

    /// <summary>
    /// Retrieves a specific doctor by ID as DTO
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>Doctor DTO or null if not found</returns>
    public Task<DoctorResponseDto?> GetDoctorAsync(int id);

    /// <summary>
    /// Updates an existing doctor's information
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <param name="entity">Updated doctor data</param>
    /// <returns>Updated doctor DTO or null if not found</returns>
    public Task<DoctorDto?> UpdateDoctorAsync(int id, DoctorDto entity);

    /// <summary>
    /// Deletes a doctor by ID
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeleteDoctorAsync(int id);

    /// <summary>
    /// Retrieves all doctors from the repository as DTOs
    /// </summary>
    /// <returns>List of all doctors as DTOs</returns>
    public Task<List<Doctor>> GetAllDoctorsWithIdAsync();
}