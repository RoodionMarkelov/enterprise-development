using Domain.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Db.Repositories;
public class DbVisitRepository(AppDbContext dbContext) : IVisitRepository
{
    public int Create(Visit entity)
    {
        var entry = dbContext.Visits.Add(entity);

        dbContext.SaveChanges();

        return entry.Entity.Id;
    }

    public List<Visit> Read()
    {
        return [.. dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient)];
    }

    public Visit? Read(int id)
    {
        return dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient).FirstOrDefault(p => p.Id == id);
    }

    public Visit? Update(int id, Visit entity)
    {
        var visit = Read(id);
        if (visit == null) return null;

        visit.Patient = entity.Patient;
        visit.Doctor = entity.Doctor;
        visit.DateOfVisit = entity.DateOfVisit;
        visit.NumberOfCabinet = entity.NumberOfCabinet;
        visit.IsAgain = entity.IsAgain;

        dbContext.SaveChanges();

        return visit;
    }

    public bool Delete(int id)
    {
        var visit = Read(id);

        if (visit == null) return false;

        dbContext.Visits.Remove(visit);
        dbContext.SaveChanges();

        return true;
    }
}
