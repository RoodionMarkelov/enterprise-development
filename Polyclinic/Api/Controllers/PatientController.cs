using Application.Service;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for patients
/// </summary>
/// <param name="service">Patient service instance</param>
/// <param name="logger">Logger instance</param>
[ApiController]
[Route("[controller]")]
public class PatientController(IPatientService service, ILogger<PatientController> logger) : ControllerBase
{
    /// <summary>
    /// Get info about patients
    /// </summary>
    /// <returns>List of patients</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PatientDto>>> Get()
    {
        logger.LogInformation("A list of existing patients has been obtained");
        var patients = await service.GetAllPatientsAsync();
        return Ok(patients);
    }

    /// <summary>
    /// Getting info about patient by ID
    /// </summary>
    /// <param name="id">ID of patient</param>
    /// <returns>Patient with id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientDto>> GetPatient(int id)
    {
        logger.LogInformation("Getting a patient with the {id}", id);
        var patient = await service.GetPatientAsync(id);
        if (patient != null) return Ok(patient);

        return NotFound();
    }

    /// <summary>
    /// Creating Patient
    /// </summary>
    /// <param name="patient">Entity of patient without id</param>
    /// <returns>Created patient ID</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<int>> CreatePatient([FromBody] PatientDto patient)
    {
        logger.LogInformation("Creating a patient with the name {fio}", patient.Name);
        var id = await service.CreatePatientAsync(patient);
        return Created($"/patient/{id}", id);
    }

    /// <summary>
    /// Update Patient if exist
    /// </summary>
    /// <param name="id">Id of patient</param>
    /// <param name="entity">New info about Patient</param>
    /// <returns>Entity of patient or null</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PatientDto?>> UpdatePatient(int id, [FromBody] PatientDto entity)
    {
        logger.LogInformation("Patient with {id} was updated", id);
        var patient = await service.UpdatePatientAsync(id, entity);
        if (patient != null) return Ok(patient);
        return NotFound();
    }

    /// <summary>
    /// Delete Patient
    /// </summary>
    /// <param name="id">Id of patient</param>
    /// <returns>No content if deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeletePatient(int id)
    {
        logger.LogInformation("Patient with {id} was deleted", id);
        await service.DeletePatientAsync(id);
        return NoContent();
    }
}