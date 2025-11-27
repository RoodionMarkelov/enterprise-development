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
    private async Task<Visit> MapToDomainAsync(VisitDto entity)
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
            PatientId = entity.PatientId, 
            Patient = patient,
            DoctorId = entity.DoctorId, 
            Doctor = doctor,
            DateOfVisit = entity.DateOfVisit,
            NumberOfCabinet = entity.NumberOfCabinet,
            IsAgain = entity.IsAgain,
        };
    }

    private static PatientDto MapToPatientDto(Patient patient)
    {
        return new PatientDto
        {
            Passport = patient.Passport,
            Name = patient.Name,
            Gender = patient.Gender,
            Birthday = patient.Birthday,
            Address = patient.Address,
            BloodGroup = patient.BloodGroup,
            RhFactor = patient.RhFactor,
            Phone = patient.Phone,
        };
    }

    /// <summary>
    /// Maps Visit entity to VisitResponseDto (с полными данными)
    /// </summary>
    private static VisitResponseDto MapToResponseDto(Visit visit)
    {
        return new VisitResponseDto
        {
            PatientId = visit.PatientId,
            Patient = visit.Patient, 
            DoctorId = visit.DoctorId,
            Doctor = visit.Doctor,      
            DateOfVisit = visit.DateOfVisit,
            NumberOfCabinet = visit.NumberOfCabinet,
            IsAgain = visit.IsAgain
        };
    }

    /// <summary>
    /// Creates a new visit from DTO data with patient and doctor validation
    /// </summary>
    public async Task<int> CreateVisitAsync(VisitDto entity)
    {
        var visit = await MapToDomainAsync(entity);
        return await repository.CreateAsync(visit);
    }

    /// <summary>
    /// Retrieves all visits from the repository as Response DTOs
    /// </summary>
    public async Task<List<VisitResponseDto>> GetAllVisitsAsync()
    {
        var visits = await repository.ReadAsync();
        return [.. visits.Select(MapToResponseDto)];
    }

    /// <summary>
    /// Retrieves a specific visit by ID as Response DTO
    /// </summary>
    public async Task<VisitResponseDto?> GetVisitAsync(int id)
    {
        var visit = await repository.ReadAsync(id);
        return visit != null ? MapToResponseDto(visit) : null;
    }

    /// <summary>
    /// Updates an existing visit's information
    /// </summary>
    public async Task<VisitResponseDto?> UpdateVisitAsync(int id, VisitDto entity)
    {
        var visitToUpdate = await MapToDomainAsync(entity);
        var updatedVisit = await repository.UpdateAsync(id, visitToUpdate);
        return updatedVisit != null ? MapToResponseDto(updatedVisit) : null;
    }

    /// <summary>
    /// Deletes a visit by ID
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public async Task<bool> DeleteVisitAsync(int id)
    {
        return await repository.DeleteAsync(id);
    }

    /// <summary>
    /// Gets patients visited by specific doctor ordered by patient name as DTOs
    /// </summary>
    /// <param name="doctorId">Doctor ID</param>
    /// <returns>List of patients ordered by name as DTOs</returns>
    public async Task<List<PatientDto>> GetVisitsByDoctorOrderedByPatientNameAsync(int doctorId)
    {
        var visits = await repository.ReadAsync();
        return [.. visits
            .Where(v => v.Doctor.Id == doctorId)
            .Select(v => v.Patient)
            .OrderBy(p => p.Name)
            .Select(MapToPatientDto)];
    }

    /// <summary>
    /// Counts repeat visits within specified date range
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <returns>Number of repeat visits</returns>
    public async Task<int> GetCountOfRepeatVisitsForRangeOfDateAsync(DateTime startDate, DateTime endDate)
    {
        var visits = await repository.ReadAsync();
        return visits.Count(v => v.IsAgain && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate);
    }

    /// <summary>
    /// Gets patients older than 30 who visited more than one doctor, ordered by birthday as DTOs
    /// </summary>
    /// <param name="currentDate">Current date for age calculation</param>
    /// <returns>List of filtered patients ordered by birthday as DTOs</returns>
    public async Task<List<PatientDto>> GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthdayAsync(DateOnly currentDate)
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
            .Select(MapToPatientDto);

        return [.. result];
    }

    /// <summary>
    /// Gets all visits for specific date range in selected cabinet as DTOs
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <param name="cabinet">Cabinet number</param>
    /// <returns>List of filtered visits as DTOs</returns>
    public async Task<List<VisitResponseDto>> GetAllVisitsForDateInSelectedCabinetAsync(DateTime startDate, DateTime endDate, string cabinet)
    {
        var visits = await repository.ReadAsync();
        return [.. visits
            .Where(v => v.NumberOfCabinet == cabinet && v.DateOfVisit >= startDate && v.DateOfVisit <= endDate)
            .Select(MapToResponseDto)];
    }
}