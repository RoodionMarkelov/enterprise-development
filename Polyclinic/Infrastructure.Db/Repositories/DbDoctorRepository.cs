using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.DTO;

namespace Infrastructure.Db.Repositories;

/// <summary>
/// Database repository implementation for Doctor entities
/// </summary>
/// <param name="dbContext">Database context</param>
public class DbDoctorRepository(AppDbContext dbContext) : IRepository<Doctor>
{
    /// <summary>
    /// Creates a new doctor entity in the database
    /// </summary>
    /// <param name="entity">Doctor entity to create</param>
    /// <returns>ID of the created doctor</returns>
    public async Task<int> CreateAsync(Doctor entity)
    {
        var entry = await dbContext.Doctors.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entry.Entity.Id;
    }

    /// <summary>
    /// Retrieves all doctors from the database
    /// </summary>
    /// <returns>List of all doctors</returns>
    public async Task<List<Doctor>> ReadAsync()
    {
        return await dbContext.Doctors.ToListAsync();
    }

    /// <summary>
    /// Retrieves a doctor by ID from the database
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>Doctor entity or null if not found</returns>
    public async Task<Doctor?> ReadAsync(int id)
    {
        return await dbContext.Doctors.FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Updates an existing doctor entity in the database
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <param name="entity">Updated doctor data</param>
    /// <returns>Updated doctor entity or null if not found</returns>
    public async Task<Doctor?> UpdateAsync(int id, Doctor entity)
    {
        var doctor = await ReadAsync(id);
        if (doctor == null) return null;

        doctor.Passport = entity.Passport;
        doctor.Name = entity.Name;
        doctor.Birthday = entity.Birthday;
        doctor.Specialization = entity.Specialization;
        doctor.WorkExperience = entity.WorkExperience;

        await dbContext.SaveChangesAsync();
        return doctor;
    }

    /// <summary>
    /// Deletes a doctor entity from the database
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeleteAsync(int id)
    {
        var doctor = await ReadAsync(id);
        if (doctor == null) return false;

        dbContext.Doctors.Remove(doctor);
        await dbContext.SaveChangesAsync();
        return true;
    }
}