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
    /// Retrieves all doctors from the repository
    /// </summary>
    /// <returns>List of all doctors</returns>
    public Task<List<Doctor>> GetAllDoctorsAsync();

    /// <summary>
    /// Gets doctors with work experience greater than or equal to target
    /// </summary>
    /// <param name="targetWorkExperience">Minimum work experience in years</param>
    /// <returns>List of filtered doctors</returns>
    public Task<List<Doctor>> GetAllWithWorkExperienceMoreTargetAsync(int targetWorkExperience);

    /// <summary>
    /// Retrieves a specific doctor by ID
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>Doctor or null if not found</returns>
    public Task<Doctor?> GetDoctorAsync(int id);

    /// <summary>
    /// Updates an existing doctor's information
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <param name="entity">Updated doctor data</param>
    /// <returns>Updated doctor or null if not found</returns>
    public Task<Doctor?> UpdateDoctorAsync(int id, Doctor entity);

    /// <summary>
    /// Deletes a doctor by ID
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeleteDoctorAsync(int id);
}