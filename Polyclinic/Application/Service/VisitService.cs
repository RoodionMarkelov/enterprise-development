using Application.DTO;
using Domain;
using Domain.Repositories;

namespace Application.Service;

/// <summary>
/// Service for managing visit operations including creation, retrieval, updating, deletion and specialized queries
/// </summary>
/// <param name="repository">Visit repository instance</param>
/// <param name="patientRepository">Patient repository instance</param>
/// <param name="doctorRepository">Doctor repository instance</param>
public class VisitService(IRepository<Visit> repository, IRepository<Patient> patientRepository, IRepository<Doctor> doctorRepository) : IVisitService
{
    /// <summary>
    /// Maps VisitDto to Visit entity with validation of patient and doctor existence
    /// </summary>
    /// <param name="entity">Visit data transfer object</param>
    /// <returns>Mapped Visit entity</returns>
    /// <exception cref="ArgumentException">Thrown when patient or doctor not found</exception>
    private async Task<Visit> MapDtoAsync(VisitDto entity)
    {
        var patient = await patientRepository.ReadAsync(entity.PatientId);
        if (patient == null)
            throw new ArgumentException($"Patient with id {entity.PatientId} not found");

        var doctor = await doctorRepository.ReadAsync(entity.DoctorId);
        if (doctor == null)
            throw new ArgumentException($"Doctor with id {entity.DoctorId} not found");

        return new Visit
        {
            Id = 0,
            PatientId = patient.Id,
            Patient = patient,
            DoctorId = doctor.Id,
            Doctor = doctor,
            DateOfVisit = entity.DateOfVisit,
            NumberOfCabinet = entity.NumberOfCabinet,
            IsAgain = entity.IsAgain,
        };
    }

    /// <summary>
    /// Creates a new visit from DTO data with patient and doctor validation
    /// </summary>
    /// <param name="entity">Visit data transfer object</param>
    /// <returns>ID of the created visit</returns>
    public async Task<int> CreateVisit(VisitDto entity)
    {
        var visit = await MapDtoAsync(entity);
        return await repository.CreateAsync(visit);
    }

    /// <summary>
    /// Retrieves all visits from the repository
    /// </summary>
    /// <returns>List of all visits</returns>
    public Task<List<Visit>> GetAllVisits()
    {
        return repository.ReadAsync();
    }

    /// <summary>
    /// Retrieves a specific visit by ID
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>Visit or null if not found</returns>
    public Task<Visit?> GetVisit(int id)
    {
        return repository.ReadAsync(id);
    }

    /// <summary>
    /// Updates an existing visit's information
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <param name="entity">Updated visit data</param>
    /// <returns>Updated visit or null if not found</returns>
    public Task<Visit?> UpdateVisit(int id, Visit entity)
    {
        return repository.UpdateAsync(id, entity);
    }

    /// <summary>
    /// Deletes a visit by ID
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeleteVisit(int id)
    {
        return repository.DeleteAsync(id);
    }

    /// <summary>
    /// Gets patients visited by specific doctor ordered by patient name
    /// </summary>
    /// <param name="doctorId">Doctor ID</param>
    /// <returns>List of patients ordered by name</returns>
    public async Task<List<Patient>> GetVisitsByDoctorOrderedByPatientName(int doctorId)
    {
        var visits = await repository.ReadAsync();
        return visits
            .Where(v => v.Doctor.Id == doctorId)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .ToList();
    }

    /// <summary>
    /// Counts repeat visits within specified date range
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <returns>Number of repeat visits</returns>
    public async Task<int> GetCountOfRepeatVisitsForRangeOfDate(DateTime startDate, DateTime endDate)
    {
        var visits = await repository.ReadAsync();
        return visits.Count(v => v.IsAgain && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate);
    }

    /// <summary>
    /// Gets patients older than 30 who visited more than one doctor, ordered by birthday
    /// </summary>
    /// <param name="currentDate">Current date for age calculation</param>
    /// <returns>List of filtered patients ordered by birthday</returns>
    public async Task<List<Patient>> GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthday(DateOnly currentDate)
    {
        var visits = await repository.ReadAsync();
        var patients = await patientRepository.ReadAsync();

        var result = visits
            .GroupBy(v => v.Patient.Id)
            .Select(g => new
            {
                PatientId = g.Key,
                Patient = patients.First(p => p.Id == g.Key),
                UniqueDoctors = g.Select(v => v.Doctor.Id).Distinct().Count()
            })
            .Where(x => x.Patient.Birthday <= currentDate.AddYears(-30) && x.UniqueDoctors > 1)
            .Select(x => x.Patient)
            .OrderBy(p => p.Birthday)
            .ToList();

        return result;
    }

    /// <summary>
    /// Gets all visits for specific date range in selected cabinet
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <param name="cabinet">Cabinet number</param>
    /// <returns>List of filtered visits</returns>
    public async Task<List<Visit>> GetAllVisitsForDateInSelectedCabinet(DateTime startDate, DateTime endDate, string cabinet)
    {
        var visits = await repository.ReadAsync();
        return visits
            .Where(v => v.NumberOfCabinet == cabinet && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate)
            .ToList();
    }
}