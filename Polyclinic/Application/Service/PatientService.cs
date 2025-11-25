using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

/// <summary>
/// Service for managing patient operations including creation, retrieval, updating, and deletion
/// </summary>
/// <param name="patientRepository"></param>
public class PatientService(IRepository<Patient> patientRepository) : IPatientService
{
    /// <summary>
    /// Maps PatientDto to Patient entity with default ID
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    private static Patient MapDto(PatientDto entity)
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
    /// Creates a new patient from DTO data
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<int> CreatePatient(PatientDto entity)
    {
        return patientRepository.CreateAsync(MapDto(entity));
    }

    /// <summary>
    /// Retrieves all patients from the repository
    /// </summary>
    /// <returns></returns>
    public Task<List<Patient>> GetAllPatients()
    {
        return patientRepository.ReadAsync();
    }

    /// <summary>
    /// Retrieves a specific patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<Patient?> GetPatient(int id)
    {
        return patientRepository.ReadAsync(id);
    }

    /// <summary>
    /// Updates an existing patient's information
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<Patient?> UpdatePatient(int id, Patient entity)
    {
        return patientRepository.UpdateAsync(id, entity);
    }

    /// <summary>
    /// Deletes a patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeletePatient(int id)
    {
        return patientRepository.DeleteAsync(id);
    }
}