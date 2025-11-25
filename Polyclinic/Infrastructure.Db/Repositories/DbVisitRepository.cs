using Domain.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db.Repositories;

/// <summary>
/// Database repository implementation for Visit entities using Entity Framework
/// </summary>
/// <param name="dbContext">Database context for data access</param>
public class DbVisitRepository(AppDbContext dbContext) : IRepository<Visit>
{
    /// <summary>
    /// Creates a new visit entity in the database
    /// </summary>
    /// <param name="entity">Visit entity to create</param>
    /// <returns>ID of the created visit</returns>
    public async Task<int> CreateAsync(Visit entity)
    {
        var entry = await dbContext.Visits.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entry.Entity.Id;
    }

    /// <summary>
    /// Retrieves all visits from the database with included Doctor and Patient entities
    /// </summary>
    /// <returns>List of all visits with related entities</returns>
    public async Task<List<Visit>> ReadAsync()
    {
        return await dbContext.Visits
            .Include(v => v.Doctor)
            .Include(v => v.Patient)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a visit by ID from the database with included Doctor and Patient entities
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>Visit entity or null if not found</returns>
    public async Task<Visit?> ReadAsync(int id)
    {
        return await dbContext.Visits
            .Include(v => v.Doctor)
            .Include(v => v.Patient)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Updates an existing visit entity in the database
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <param name="entity">Updated visit data</param>
    /// <returns>Updated visit entity or null if not found</returns>
    public async Task<Visit?> UpdateAsync(int id, Visit entity)
    {
        var visit = await ReadAsync(id);
        if (visit == null) return null;

        visit.Patient = entity.Patient;
        visit.Doctor = entity.Doctor;
        visit.DateOfVisit = entity.DateOfVisit;
        visit.NumberOfCabinet = entity.NumberOfCabinet;
        visit.IsAgain = entity.IsAgain;

        await dbContext.SaveChangesAsync();
        return visit;
    }

    /// <summary>
    /// Deletes a visit entity from the database
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeleteAsync(int id)
    {
        var visit = await ReadAsync(id);
        if (visit == null) return false;

        dbContext.Visits.Remove(visit);
        await dbContext.SaveChangesAsync();
        return true;
    }
}