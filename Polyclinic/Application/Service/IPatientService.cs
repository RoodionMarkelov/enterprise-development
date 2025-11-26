using Application.DTO;
using Domain;

namespace Application.Service;

/// <summary>
/// Service interface for patient management operations
/// </summary>
public interface IPatientService
{
    /// <summary>
    /// Creates a new patient from DTO data
    /// </summary>
    /// <param name="entity">Patient data transfer object</param>
    /// <returns>ID of the created patient</returns>
    public Task<int> CreatePatientAsync(PatientDto entity);

    /// <summary>
    /// Retrieves all patients from the repository as DTOs
    /// </summary>
    /// <returns>List of all patients as DTOs</returns>
    public Task<List<PatientDto>> GetAllPatientsAsync();

    /// <summary>
    /// Retrieves a specific patient by ID as DTO
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>Patient DTO or null if not found</returns>
    public Task<PatientDto?> GetPatientAsync(int id);

    /// <summary>
    /// Updates an existing patient's information
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <param name="entity">Updated patient data</param>
    /// <returns>Updated patient DTO or null if not found</returns>
    public Task<PatientDto?> UpdatePatientAsync(int id, PatientDto entity);

    /// <summary>
    /// Deletes a patient by ID
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeletePatientAsync(int id);
}