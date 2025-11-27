using Application.DTO;

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
    public Task<int> CreateVisitAsync(VisitDto entity);

    /// <summary>
    /// Retrieves all visits from the repository as DTOs
    /// </summary>
    /// <returns>List of all visits as DTOs</returns>
    public Task<List<VisitResponseDto>> GetAllVisitsAsync();

    /// <summary>
    /// Retrieves a specific visit by ID as DTO
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>Visit DTO or null if not found</returns>
    public Task<VisitResponseDto?> GetVisitAsync(int id);

    /// <summary>
    /// Updates an existing visit's information
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <param name="entity">Updated visit data</param>
    /// <returns>Updated visit DTO or null if not found</returns>
    public Task<VisitResponseDto?> UpdateVisitAsync(int id, VisitDto entity);

    /// <summary>
    /// Deletes a visit by ID
    /// </summary>
    /// <param name="id">Visit ID</param>
    /// <returns>True if deleted successfully, false if not found</returns>
    public Task<bool> DeleteVisitAsync(int id);

    /// <summary>
    /// Gets patients visited by specific doctor ordered by patient name as DTOs
    /// </summary>
    /// <param name="doctorId">Doctor ID</param>
    /// <returns>List of patients ordered by name as DTOs</returns>
    public Task<List<PatientResponseDto>> GetVisitsByDoctorOrderedByPatientNameAsync(int doctorId);

    /// <summary>
    /// Counts repeat visits within specified date range
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <returns>Number of repeat visits</returns>
    public Task<int> GetCountOfRepeatVisitsForRangeOfDateAsync(DateTime startDate, DateTime endDate);

    /// <summary>
    /// Gets patients older than 30 who visited more than one doctor, ordered by birthday as DTOs
    /// </summary>
    /// <param name="currentDate">Current date for age calculation</param>
    /// <returns>List of filtered patients ordered by birthday as DTOs</returns>
    public Task<List<PatientResponseDto>> GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthdayAsync(DateOnly currentDate);

    /// <summary>
    /// Gets all visits for specific date range in selected cabinet as DTOs
    /// </summary>
    /// <param name="startDate">Start date of the range</param>
    /// <param name="endDate">End date of the range</param>
    /// <param name="cabinet">Cabinet number</param>
    /// <returns>List of filtered visits as DTOs</returns>
    public Task<List<VisitResponseDto>> GetAllVisitsForDateInSelectedCabinetAsync(DateTime startDate, DateTime endDate, string cabinet);
}