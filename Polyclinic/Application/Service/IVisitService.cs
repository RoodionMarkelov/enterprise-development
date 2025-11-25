using Application.DTO;
using Domain;

namespace Application.Service;

/// <summary>
/// Service interface for visit management operations
/// </summary>
public interface IVisitService
{
    /// <summary>
    /// Creates a new visit from DTO data with patient and doctor validation
    /// </summary>
    /// <param name="entity">Visit data transfer object</param>
    /// <returns>ID of the created visit</returns>
    public Task<int> CreateVisit(VisitDto entity);

    /// <summary>
    /// Retrieves all visits from the repository
    /// </summary>
    /// <returns>List of all visits</returns>
    public Task<List<Visit>> GetAllVisits();

    /// <summary>
    /// Retrieves a specific visit by ID
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>Visit or null if not found</returns>
    public Task<Visit?> GetVisit(int id);

    /// <summary>
    /// Updates an existing visit's information
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <param name="entity">Updated visit data</param>
    /// <returns>Updated visit or null if not found</returns>
    public Task<Visit?> UpdateVisit(int id, Visit entity);

    /// <summary>
    /// Deletes a visit by ID
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeleteVisit(int id);

    /// <summary>
    /// Gets patients visited by specific doctor ordered by patient name
    /// </summary>
    /// <param name="doctorId">Doctor ID</param>
    /// <returns>List of patients ordered by name</returns>
    public Task<List<Patient>> GetVisitsByDoctorOrderedByPatientName(int doctorId);

    /// <summary>
    /// Counts repeat visits within specified date range
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <returns>Number of repeat visits</returns>
    public Task<int> GetCountOfRepeatVisitsForRangeOfDate(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Gets patients older than 30 who visited more than one doctor, ordered by birthday
    /// </summary>
    /// <param name="currentDate">Current date for age calculation</param>
    /// <returns>List of filtered patients ordered by birthday</returns>
    public Task<List<Patient>> GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthday(DateOnly currentDate);

    /// <summary>
    /// Gets all visits for specific date range in selected cabinet
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <param name="cabinet">Cabinet number</param>
    /// <returns>List of filtered visits</returns>
    public Task<List<Visit>> GetAllVisitsForDateInSelectedCabinet(DateTime startDate, DateTime endDate, string cabinet);
}