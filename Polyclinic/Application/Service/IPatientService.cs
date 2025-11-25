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
    public Task<int> CreatePatient(PatientDto entity);

    /// <summary>
    /// Retrieves all patients from the repository
    /// </summary>
    /// <returns>List of all patients</returns>
    public Task<List<Patient>> GetAllPatients();

    /// <summary>
    ///  Retrieves a specific patient by ID
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>Patient or null if not found</returns>
    public Task<Patient?> GetPatient(int id);

    /// <summary>
    /// Updates an existing patient's information
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <param name="entity">Updated patient data</param>
    /// <returns>Updated patient or null if not found</returns>
    public Task<Patient?> UpdatePatient(int id, Patient entity);

    /// <summary>
    /// Deletes a patient by ID
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeletePatient(int id);
}
