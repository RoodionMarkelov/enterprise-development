using Domain;
using Domain.Repositories;
using Infrastructure.InMemory.Seeders;

namespace Infrastructure.InMemory.Repositories;
public class InMemoryPatientRepository : IPatientRepository
{
    private readonly List<Patient> _items = [];
    
    private int _currentId = 1;

    public InMemoryPatientRepository(InMemoryPatientRepositorySeeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.GetItems();
        _currentId = seeder.GetCurrentId();
    }

    public int Create(Patient entity)
    {
        entity.Id = _currentId + 1;
        _currentId++;
        _items.Add(entity);
        return entity.Id;
    }

    public List<Patient> Read()
    {
        return _items;
    }

    public Patient? Read(string passport)
    {
        return _items.FirstOrDefault(item => item.Passport == passport);
    }

    public Patient? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Patient? Update(int id, Patient entity)
    {
        var existingEntity = Read(id);
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
    }

    public bool Delete(int id)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return false;

        _items.Remove(existingEntity);
        return true;
    }
}
