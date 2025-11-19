using Domain;
using Domain.Repositories;

namespace Infrastructure.Db.Repositories;
public class DbPatientRepository(AppDbContext dbContext) : IPatientRepository
{
    public int Create(Patient entity)
    {
        var entry = dbContext.Patients.Add(entity);

        dbContext.SaveChanges();

        return entry.Entity.Id;
    }

    public List<Patient> Read()
    {
        return [..dbContext.Patients];
    }

    public Patient? Read(string passport)
    {
        return dbContext.Patients.FirstOrDefault(p => p.Passport == passport);
    }

    public Patient? Read(int id)
    {
        return dbContext.Patients.FirstOrDefault(p => p.Id == id);
    }

    public Patient? Update(int id, Patient entity)
    {
        var patient = Read(id);
        if (patient == null) return null;

        patient.Passport = entity.Passport;
        patient.Name = entity.Name;
        patient.Gender = entity.Gender;
        patient.Birthday = entity.Birthday;
        patient.Address = entity.Address;
        patient.BloodGroup = entity.BloodGroup;
        patient.RhFactor = entity.RhFactor;
        patient.Phone = entity.Phone;

        dbContext.SaveChanges();

        return patient;
    }

    public bool Delete(int id)
    {
        var patient = Read(id);

        if (patient == null) return false;

        dbContext.Patients.Remove(patient);
        dbContext.SaveChanges();

        return true;
    }
}
