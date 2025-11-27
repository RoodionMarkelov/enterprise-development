using Domain;
using Domain.Repositories;
using Domain.Seeder;

namespace Infrastructure.InMemory.Repositories;

/// <summary>
/// In-memory repository implementation for Visit entities with data seeding support
/// </summary>
/// <param name="seeder">Optional data seeder for initial population</param>
public class InMemoryVisitRepository : IRepository<Visit>
{
    private readonly List<Visit> _items = [];
    private int _currentId = 1;

    /// <summary>
    /// Initializes a new instance of the in-memory visit repository
    /// </summary>
    /// <param name="seeder">Optional data seeder for initial population</param>
    public InMemoryVisitRepository(DataSeeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.Visits;
        _currentId = seeder.Visits.Count;
    }

    /// <summary>
    /// Creates a new visit entity in memory
    /// </summary>
    /// <param name="entity">Visit entity to create</param>
    /// <returns>ID of the created visit</returns>
    public async Task<int> CreateAsync(Visit entity)
    {
        return await Task.Run(() =>
        {
            entity.Id = _currentId;
            _items.Add(entity);
            ++_currentId;
            return entity.Id;
        });
    }

    /// <summary>
    /// Retrieves all visits from memory
    /// </summary>
    /// <returns>List of all visits</returns>
    public async Task<List<Visit>> ReadAsync()
    {
        return await Task.Run(() => _items);
    }

    /// <summary>
    /// Retrieves a visit by ID from memory
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>Visit entity or null if not found</returns>
    public async Task<Visit?> ReadAsync(int id)
    {
        return await Task.Run(() => _items.FirstOrDefault(item => item.Id == id));
    }

    /// <summary>
    /// Updates an existing visit entity in memory
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <param name="entity">Updated visit data</param>
    /// <returns>Updated visit entity or null if not found</returns>
    public async Task<Visit?> UpdateAsync(int id, Visit entity)
    {
        return await Task.Run(() =>
        {
            var existingEntity = _items.FirstOrDefault(item => item.Id == id);
            if (existingEntity == null) return null;

            existingEntity.PatientId = entity.PatientId;
            existingEntity.Patient = entity.Patient;
            existingEntity.DoctorId = entity.DoctorId;
            existingEntity.Doctor = entity.Doctor;
            existingEntity.DateOfVisit = entity.DateOfVisit;
            existingEntity.NumberOfCabinet = entity.NumberOfCabinet;
            existingEntity.IsAgain = entity.IsAgain;

            return existingEntity;
        });
    }

    /// <summary>
    /// Deletes a visit entity from memory
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeleteAsync(int id)
    {
        return await Task.Run(() =>
        {
            var existingEntity = _items.FirstOrDefault(item => item.Id == id);
            if (existingEntity == null) return false;

            return _items.Remove(existingEntity);
        });
    }
}