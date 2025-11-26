using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

/// <summary>
/// Service for managing patient operations including creation, retrieval, updating, and deletion
/// </summary>
/// <param name="patientRepository">Patient repository instance</param>
public class PatientService(IRepository<Patient> patientRepository) : IPatientService
{
    /// <summary>
    /// Maps PatientDto to Patient entity with default ID
    /// </summary>
    /// <param name="entity">Patient data transfer object</param>
    /// <returns>Mapped Patient entity</returns>
    private static Patient MapToDomain(PatientDto entity)
    {
        return new Patient
        {
            Id = 0,
            Passport = entity.Passport,
            Name = entity.Name,
            Gender = entity.Gender,
            Birthday = entity.Birthday,
            Address = entity.Address,
            BloodGroup = entity.BloodGroup,
            RhFactor = entity.RhFactor,
            Phone = entity.Phone,
        };
    }

    /// <summary>
    /// Maps Patient entity to PatientDto
    /// </summary>
    /// <param name="patient">Patient entity</param>
    /// <returns>Mapped Patient DTO</returns>
    private static PatientDto MapToDto(Patient patient)
    {
        return new PatientDto
        {
            Passport = patient.Passport,
            Name = patient.Name,
            Gender = patient.Gender,
            Birthday = patient.Birthday,
            Address = patient.Address,
            BloodGroup = patient.BloodGroup,
            RhFactor = patient.RhFactor,
            Phone = patient.Phone,
        };
    }

    /// <summary>
    /// Creates a new patient from DTO data
    /// </summary>
    /// <param name="entity">Patient data transfer object</param>
    /// <returns>ID of the created patient</returns>
    public async Task<int> CreatePatientAsync(PatientDto entity)
    {
        var patient = MapToDomain(entity);
        return await patientRepository.CreateAsync(patient);
    }

    /// <summary>
    /// Retrieves all patients from the repository as DTOs
    /// </summary>
    /// <returns>List of all patients as DTOs</returns>
    public async Task<List<PatientDto>> GetAllPatientsAsync()
    {
        var patients = await patientRepository.ReadAsync();
        return patients.Select(MapToDto).ToList();
    }

    /// <summary>
    /// Retrieves a specific patient by ID as DTO
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>Patient DTO or null if not found</returns>
    public async Task<PatientDto?> GetPatientAsync(int id)
    {
        var patient = await patientRepository.ReadAsync(id);
        return patient != null ? MapToDto(patient) : null;
    }

    /// <summary>
    /// Updates an existing patient's information
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <param name="entity">Updated patient data</param>
    /// <returns>Updated patient DTO or null if not found</returns>
    public async Task<PatientDto?> UpdatePatientAsync(int id, PatientDto entity)
    {
        var patientToUpdate = MapToDomain(entity);
        patientToUpdate.Id = id;

        var updatedPatient = await patientRepository.UpdateAsync(id, patientToUpdate);
        return updatedPatient != null ? MapToDto(updatedPatient) : null;
    }

    /// <summary>
    /// Deletes a patient by ID
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeletePatientAsync(int id)
    {
        return await patientRepository.DeleteAsync(id);
    }
}