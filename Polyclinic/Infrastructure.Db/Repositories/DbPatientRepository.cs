using Domain;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;

namespace Infrastructure.Db.Repositories;

/// <summary>
/// Database repository implementation for Patient entities using Entity Framework
/// </summary>
/// <param name="dbContext">Database context for data access</param>
public class DbPatientRepository(AppDbContext dbContext) : IRepository<Patient>
{
    /// <summary>
    /// Creates a new patient entity in the database
    /// </summary>
    /// <param name="entity">Patient entity to create</param>
    /// <returns>ID of the created patient</returns>
    public async Task<int> CreateAsync(Patient entity)
    {
        var entry = await dbContext.Patients.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entry.Entity.Id;
    }

    /// <summary>
    /// Retrieves all patients from the database
    /// </summary>
    /// <returns>List of all patients</returns>
    public async Task<List<Patient>> ReadAsync()
    {
        return await dbContext.Patients.ToListAsync();
    }

    /// <summary>
    /// Retrieves a patient by ID from the database
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>Patient entity or null if not found</returns>
    public async Task<Patient?> ReadAsync(int id)
    {
        return await dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Updates an existing patient entity in the database
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <param name="entity">Updated patient data</param>
    /// <returns>Updated patient entity or null if not found</returns>
    public async Task<Patient?> UpdateAsync(int id, Patient entity)
    {
        var patient = await ReadAsync(id);
        if (patient == null) return null;

        patient.Passport = entity.Passport;
        patient.Name = entity.Name;
        patient.Gender = entity.Gender;
        patient.Birthday = entity.Birthday;
        patient.Address = entity.Address;
        patient.BloodGroup = entity.BloodGroup;
        patient.RhFactor = entity.RhFactor;
        patient.Phone = entity.Phone;

        await dbContext.SaveChangesAsync();
        return patient;
    }

    /// <summary>
    /// Deletes a patient entity from the database
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeleteAsync(int id)
    {
        var patient = await ReadAsync(id);
        if (patient == null) return false;

        dbContext.Patients.Remove(patient);
        await dbContext.SaveChangesAsync();
        return true;
    }
}