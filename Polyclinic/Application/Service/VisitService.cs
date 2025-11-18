using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

/// <summary>
/// Service for managing visit operations including creation, retrieval, updating, deletion and specialized queries
/// </summary>
/// <param name="repository"></param>
/// <param name="patientRepository"></param>
/// <param name="doctorRepository"></param>
public class VisitService(IVisitRepository repository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
{
    /// <summary>
    /// Maps VisitDto to Visit entity with validation of patient and doctor existence
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="patientRepository"></param>
    /// <param name="doctorRepository"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
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

    /// <summary>
    /// Creates a new visit from DTO data with patient and doctor validation
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public int CreateVisit(VisitDto entity)
    {
        return repository.Create(MapDto(entity, patientRepository, doctorRepository));
    }

    /// <summary>
    /// Retrieves all visits from the repository
    /// </summary>
    /// <returns></returns>
    public List<Visit> GetAllVisits()
    {
        return repository.Read();
    }

    /// <summary>
    /// Retrieves a specific visit by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Visit? GetVisit(int id)
    {
        return repository.Read(id);
    }

    /// <summary>
    /// Updates an existing visit's information
    /// </summary>
    /// <param name="id"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Visit? UpdateVisit(int id, Visit entity)
    {
        return repository.Update(id, entity);
    }

    /// <summary>
    /// Deletes a visit by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteVisit(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Gets patients visited by specific doctor ordered by patient name
    /// </summary>
    /// <param name="doctorId"></param>
    /// <returns></returns>
    public List<Patient> GetVisitsByDoctorOrderedByPatientName(int doctorId)
    {
        return repository.Read()
            .Where(v => v.Doctor.Id == doctorId)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .ToList();
    }

    /// <summary>
    /// Counts repeat visits within specified date range
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public int GetCountOfRepeatVisitsForRangeOfDate(DateTime startDate, DateTime endDate)
    {
        return repository.Read()
            .Count(v => v.IsAgain && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate);
    }

    /// <summary>
    /// Gets patients older than 30 who visited more than one doctor, ordered by birthday
    /// </summary>
    /// <param name="currentDate"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Gets all visits for specific date range in selected cabinet
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="cabinet"></param>
    /// <returns></returns>
    public List<Visit> GetAllVisitsForDateInSelectedCabinet(DateTime startDate, DateTime endDate, string cabinet)
    {
        return repository.Read()
            .Where(v => v.NumberOfCabinet == cabinet && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate)
            .ToList();
    }
}