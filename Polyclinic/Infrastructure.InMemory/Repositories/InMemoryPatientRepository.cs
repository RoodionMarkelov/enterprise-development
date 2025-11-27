using Domain;
using Domain.Repositories;
using Domain.Seeder;


namespace Infrastructure.InMemory.Repositories;

/// <summary>
/// In-memory repository implementation for Patient entities with data seeding support
/// </summary>
/// <param name="seeder">Optional data seeder for initial population</param>
public class InMemoryPatientRepository : IRepository<Patient>
{
    private readonly List<Patient> _items = [];
    private int _currentId = 1;

    /// <summary>
    /// Initializes a new instance of the in-memory patient repository
    /// </summary>
    /// <param name="seeder">Optional data seeder for initial population</param>
    public InMemoryPatientRepository(DataSeeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.Patients;
        _currentId = seeder.Patients.Count;
    }

    /// <summary>
    /// Creates a new patient entity in memory
    /// </summary>
    /// <param name="entity">Patient entity to create</param>
    /// <returns>ID of the created patient</returns>
    public async Task<int> CreateAsync(Patient entity)
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
    /// Retrieves all patients from memory
    /// </summary>
    /// <returns>List of all patients</returns>
    public async Task<List<Patient>> ReadAsync()
    {
        return await Task.Run(() => _items);
    }

    /// <summary>
    /// Retrieves a patient by ID from memory
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <returns>Patient entity or null if not found</returns>
    public async Task<Patient?> ReadAsync(int id)
    {
        return await Task.Run(() => _items.FirstOrDefault(item => item.Id == id));
    }

    /// <summary>
    /// Updates an existing patient entity in memory
    /// </summary>
    /// <param name="id">Patient ID</param>
    /// <param name="entity">Updated patient data</param>
    /// <returns>Updated patient entity or null if not found</returns>
    public async Task<Patient?> UpdateAsync(int id, Patient entity)
    {
        return await Task.Run(() =>
        {
            var existingEntity = _items.FirstOrDefault(item => item.Id == id);
            if (existingEntity == null) return null;

            existingEntity.Passport = entity.Passport;
            existingEntity.Name = entity.Name;
            existingEntity.Gender = entity.Gender;
            existingEntity.Birthday = entity.Birthday;
            existingEntity.Address = entity.Address;
            existingEntity.BloodGroup = entity.BloodGroup;
            existingEntity.RhFactor = entity.RhFactor;
            existingEntity.Phone = entity.Phone;

            return existingEntity;
        });
    }

    /// <summary>
    /// Deletes a patient entity from memory
    /// </summary>
    /// <param name="id">Patient ID</param>
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