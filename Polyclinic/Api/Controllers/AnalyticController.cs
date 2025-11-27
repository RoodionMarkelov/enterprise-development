using Application.Service;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for analytical queries and statistics
/// </summary>
/// <param name="visitService">Visit service instance</param>
/// <param name="doctorService">Doctor service instance</param>
/// <param name="logger">Logger instance</param>
[ApiController]
[Route("api/[controller]")]
public class AnalyticController(
    IVisitService visitService,
    IDoctorService doctorService,
    ILogger<AnalyticController> logger) : ControllerBase
{
    /// <summary>
    /// Get patients of a specific doctor ordered by patient name
    /// </summary>
    /// <param name="doctorId">Doctor ID</param>
    /// <returns>List of patients</returns>
    [HttpGet("doctors/{doctorId}/patients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PatientResponseDto>>> GetDoctorPatients(int doctorId)
    {
        logger.LogInformation("Getting patients for doctor {DoctorId}", doctorId);
        var patients = await visitService.GetVisitsByDoctorOrderedByPatientNameAsync(doctorId);
        return Ok(patients);
    }

    /// <summary>
    /// Get count of repeat visits within date range
    /// </summary>
    /// <param name="startDate">Start date</param>
    /// <param name="endDate">End date</param>
    /// <returns>Count of repeat visits</returns>
    [HttpGet("visits/repeat-count")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> GetRepeatVisitsCount(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        logger.LogInformation("Getting repeat visits count from {StartDate} to {EndDate}", startDate, endDate);
        var count = await visitService.GetCountOfRepeatVisitsForRangeOfDateAsync(startDate, endDate);
        return Ok(count);
    }

    /// <summary>
    /// Get patients older than 30 who visited more than one doctor
    /// </summary>
    /// <param name="currentDate">Current date for age calculation (default: today)</param>
    /// <returns>List of patients</returns>
    [HttpGet("patients/older-than-30-multiple-doctors")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PatientResponseDto>>> GetPatientsOlderThan30WithMultipleDoctors(
        [FromQuery] DateTime currentDate = default)
    {
        if (currentDate == default)
            currentDate = DateTime.Today;

        logger.LogInformation("Getting patients older than 30 with multiple doctors as of {CurrentDate}", currentDate);

        var currentDateOnly = DateOnly.FromDateTime(currentDate);
        var patients = await visitService.GetAllPatientsOlderAgeToSomeDoctorsOrderedByBirthdayAsync(currentDateOnly);
        return Ok(patients);
    }

    /// <summary>
    /// Get all visits in specified cabinet within date range
    /// </summary>
    /// <param name="startDate">Start date</param>
    /// <param name="endDate">End date</param>
    /// <param name="cabinet">Cabinet number</param>
    /// <returns>List of visits</returns>
    [HttpGet("visits/by-cabinet")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<VisitResponseDto>>> GetVisitsByCabinet(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        [FromQuery] string cabinet)
    {
        logger.LogInformation("Getting visits in cabinet {Cabinet} from {StartDate} to {EndDate}", cabinet, startDate, endDate);
        var visits = await visitService.GetAllVisitsForDateInSelectedCabinetAsync(startDate, endDate, cabinet);
        return Ok(visits);
    }

    /// <summary>
    /// Get doctors with work experience more than specified minimum
    /// </summary>
    /// <param name="minExperience">Minimum work experience in years</param>
    /// <returns>List of doctors</returns>
    [HttpGet("doctors/experienced")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DoctorResponseDto>>> GetExperiencedDoctors([FromQuery] int minExperience)
    {
        logger.LogInformation("Getting doctors with experience more than {MinExperience} years", minExperience);
        var doctors = await doctorService.GetAllWithWorkExperienceMoreTargetAsync(minExperience);
        return Ok(doctors);
    }
}