using Domain;
using Domain.Repositories;
using Domain.Seeder;


namespace Infrastructure.InMemory.Repositories;

/// <summary>
/// In-memory repository implementation for Doctor entities with data seeding support
/// </summary>
/// <param name="seeder">Optional data seeder for initial population</param>
public class InMemoryDoctorRepository : IRepository<Doctor>
{
    private readonly List<Doctor> _items = [];
    private int _currentId = 1;

    /// <summary>
    /// Initializes a new instance of the in-memory doctor repository
    /// </summary>
    /// <param name="seeder">Optional data seeder for initial population</param>
    public InMemoryDoctorRepository(DataSeeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.Doctors;
        _currentId = seeder.Doctors.Count();
    }

    /// <summary>
    /// Creates a new doctor entity in memory
    /// </summary>
    /// <param name="entity">Doctor entity to create</param>
    /// <returns>ID of the created doctor</returns>
    public async Task<int> CreateAsync(Doctor entity)
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
    /// Retrieves all doctors from memory
    /// </summary>
    /// <returns>List of all doctors</returns>
    public async Task<List<Doctor>> ReadAsync()
    {
        return await Task.Run(() => _items);
    }

    /// <summary>
    /// Retrieves a doctor by ID from memory
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <returns>Doctor entity or null if not found</returns>
    public async Task<Doctor?> ReadAsync(int id)
    {
        return await Task.Run(() => _items.FirstOrDefault(item => item.Id == id));
    }

    /// <summary>
    /// Updates an existing doctor entity in memory
    /// </summary>
    /// <param name="id">Doctor ID</param>
    /// <param name="entity">Updated doctor data</param>
    /// <returns>Updated doctor entity or null if not found</returns>
    public async Task<Doctor?> UpdateAsync(int id, Doctor entity)
    {
        return await Task.Run(() =>
        {
            var existingEntity = _items.FirstOrDefault(item => item.Id == id);
            if (existingEntity == null) return null;

            existingEntity.Passport = entity.Passport;
            existingEntity.Name = entity.Name;
            existingEntity.Birthday = entity.Birthday;
            existingEntity.Specialization = entity.Specialization;
            existingEntity.WorkExperience = entity.WorkExperience;

            return existingEntity;
        });
    }

    /// <summary>
    /// Deletes a doctor entity from memory
    /// </summary>
    /// <param name="id">Doctor ID</param>
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