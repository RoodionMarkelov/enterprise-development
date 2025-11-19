using Domain;
using Domain.Repositories;

namespace Infrastructure.Db.Repositories;
public class DbDoctorRepository(AppDbContext dbContext) : IDoctorRepository
{
    public int Create(Doctor entity)
    {
        var entry = dbContext.Doctors.Add(entity);

        dbContext.SaveChanges();

        return entry.Entity.Id;
    }

    public List<Doctor> Read()
    {
        return [.. dbContext.Doctors];
    }

    public Doctor? Read(string passport)
    {
        return dbContext.Doctors.FirstOrDefault(p => p.Passport == passport);
    }

    public Doctor? Read(int id)
    {
        return dbContext.Doctors.FirstOrDefault(p => p.Id == id);
    }

    public Doctor? Update(int id, Doctor entity)
    {
        var doctor = Read(id);
        if (doctor == null) return null;

        doctor.Passport = entity.Passport;
        doctor.Name = entity.Name;
        doctor.Birthday = entity.Birthday;
        doctor.Specialization = entity.Specialization;
        doctor.WorkExperience = entity.WorkExperience;

        dbContext.SaveChanges();

        return doctor;
    }

    public bool Delete(int id)
    {
        var doctor = Read(id);

        if (doctor == null) return false;

        dbContext.Doctors.Remove(doctor);
        dbContext.SaveChanges();

        return true;
    }
}
