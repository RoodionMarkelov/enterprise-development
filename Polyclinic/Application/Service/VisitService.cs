using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

public class VisitService(IVisitRepository repository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
{
    private static Visit MapDto(VisitDto entity, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    {
        var patient = patientRepository.Read(entity.Patient.Passport);
        if (patient == null)
            throw new ArgumentException($"Patient with passport {entity.Patient.Passport} not found");

        var doctor = doctorRepository.Read(entity.Doctor.Passport);
        if (doctor == null)
            throw new ArgumentException($"Doctor with passport {entity.Doctor.Passport} not found");

        return new Visit
        {
            Id = 0,
            Patient = patient,
            Doctor = doctor,
            DateOfVisit = entity.DateOfVisit,
            NumberOfCabinet = entity.NumberOfCabinet,
            IsAgain = entity.IsAgain,
        };

    }

    public int CreatePatinet(VisitDto entity)
    {
        return repository.Create(MapDto(entity, patientRepository, doctorRepository));
    }

    public List<Patient> GetVisitsByDoctorOrderedByPatientName(int doctorId)
    {
        return repository.Read()
            .Where(v => v.Doctor.Id == doctorId)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .ToList();
    }

    public int GetCountOfRepeatVisitsForRangeOfDate(DateTime startDate, DateTime endDate)
    {
        return repository.Read()
            .Count(v => v.IsAgain && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate);
    }

    public List<Patient> GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthday(DateOnly currentDate)
    {
        return repository.Read()
            .GroupBy(v => v.Patient.Id)
            .Select(g => new
            {
                PatientId = g.Key,
                Patient = patientRepository.Read().First(p => p.Id == g.Key),
                UniqueDoctors = g.Select(v => v.Doctor.Id).Distinct().Count()
            })
            .Where(x => x.Patient.Birthday <= currentDate.AddYears(-30) && x.UniqueDoctors > 1)
            .Select(x => x.Patient)
            .OrderBy(p => p.Birthday)
            .ToList();
    }

    public List<Visit> GetAllVisitsForDateInSelectedCabinet(DateTime startDate, DateTime endDate, string cabinet)
    {
        return repository.Read()
            .Where(v => v.NumberOfCabinet == cabinet && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate)
            .ToList();
    }
}

