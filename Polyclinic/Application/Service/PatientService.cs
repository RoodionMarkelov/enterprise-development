using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

/// <summary>
/// Service for managing patient operations including creation, retrieval, updating, and deletion
/// </summary>
/// <param name="repository"></param>
public class PatientService(IPatientRepository repository)
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
    public int CreatePatient(PatientDto entity)
    {
        return repository.Create(MapDto(entity));
    }

    /// <summary>
    /// Retrieves all patients from the repository
    /// </summary>
    /// <returns></returns>
    public List<Patient> GetAllPatients()
    {
        return repository.Read();
    }

    /// <summary>
    /// Retrieves a specific patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Patient? GetPatient(int id)
    {
        return repository.Read(id);
    }

    /// <summary>
    /// Updates an existing patient's information
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Patient? UpdatePatient(int id, Patient entity)
    {
        return repository.Update(id, entity);
    }

    /// <summary>
    /// Deletes a patient by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeletePatient(int id)
    {
        return repository.Delete(id);
    }
}