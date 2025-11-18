using Domain;
using Domain.Repositories;
using Infrastructure.InMemory.Seeders;

namespace Infrastructure.InMemory.Repositories;
public class InMemoryVisitRepository : IVisitRepository
{
    private readonly List<Visit> _items = [];
    
    private int _currentId = 1;

    public InMemoryVisitRepository(InMemoryVisitRepositorySeeder? seeder)
    {
        if (seeder == null) return;

        _items = seeder.GetItems();
        _currentId = seeder.GetCurrentId();
    }

    public int Create(Visit entity)
    {
        entity.Id = _currentId + 1;
        _currentId++;
        _items.Add(entity);
        return entity.Id;
    }

    public List<Visit> Read()
    {
        return _items;
    }

    public Visit? Read(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public Visit? Update(int id, Visit entity)
    {
        var existingEntity = Read(id);
        if (existingEntity == null) return null;

        existingEntity.Patient = entity.Patient;
        existingEntity.Doctor = entity.Doctor;
        existingEntity.DateOfVisit = entity.DateOfVisit;
        existingEntity.NumberOfCabinet = entity.NumberOfCabinet;
        existingEntity.IsAgain = entity.IsAgain;

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