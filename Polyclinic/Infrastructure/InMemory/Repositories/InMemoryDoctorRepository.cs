using Domain;
using Domain.Repositories;
using Infrastructure.InMemory.Seeders;

namespace Infrastructure.InMemory.Repositories;
public class InMemoryDoctorRepository : IDoctorRepository
{
    private readonly List<Doctor> _items = [];

    private int _currentId = 1;

    public InMemoryDoctorRepository(InMemoryDoctorRepositorySeeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.GetItems();
        _currentId = seeder.GetCurrentId();
    }

    public int Create(Doctor entity)
    {
        entity.Id = _currentId + 1;
        _currentId++;
        _items.Add(entity);
        return entity.Id;
    }

    public List<Doctor> Read()
    {
        return _items;
    }

    public Doctor? Read(string passport)
    {
        return _items.FirstOrDefault(item => item.Passport == passport);
    }

    public Doctor? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Doctor? Update(int id, Doctor entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;

        existingEntity.Passport = entity.Passport;
        existingEntity.Name = entity.Name;
        existingEntity.Birthday = entity.Birthday;
        existingEntity.Specialization = entity.Specialization;
        existingEntity.WorkExperience = entity.WorkExperience;

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
