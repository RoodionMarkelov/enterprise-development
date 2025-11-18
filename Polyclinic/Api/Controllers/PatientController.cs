using Application.Service;
using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for patients
/// </summary>
/// <param name="service"></param>
/// <param name="logger"></param>
[ApiController]
[Route("[controller]")]
public class PatientController(PatientService service, ILogger<PatientController> logger) : ControllerBase
{
    /// <summary>
    /// Get info about patients
    /// </summary>
    /// <returns>List of patients</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Patient>> Get()
    {
        logger.LogInformation("A list of existing patients has been obtained");
        return Ok(service.GetAllPatients());
    }

    /// <summary>
    /// Getting info about patient by ID
    /// </summary>
    /// <param name="id"> id of patient</param>
    /// <returns>Patient with id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Patient> GetPatient(int id)
    {
        logger.LogInformation("Getting a patient with the {id}", id);
        var patient = service.GetPatient(id);
        if (patient != null) return Ok(patient);

        return NotFound();
    }

    /// <summary>
    /// Creating Patient
    /// </summary>
    /// <param name="patient">Entity of patient without id</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<int> CreatePatient([FromBody] PatientDto patient)
    {
        logger.LogInformation("Creating a patient with the name {fio}", patient.Name);
        var id = service.CreatePatient(patient);
        return Created($"/patient/{id}", id); 
    }

    /// <summary>
    /// Uptade Patient if exist
    /// </summary>
    /// <param name="id">Id of patient</param>
    /// <param name="entity">New info about Patient</param>
    /// <returns>Entity of patient or null</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Patient?> UpdatePatient(int id, [FromBody] Patient entity)
    {
        logger.LogInformation("Patient with {id} was updated", id);
        var patient = service.UpdatePatient(id, entity);
        if (patient != null) return Ok(patient);
        return NotFound();
    }

    /// <summary>
    /// Delete Patient
    /// </summary>
    /// <param name="id">Id of patient</param>
    /// <returns>True if delete</returns>
    [HttpDelete("{id}")] 
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> DeletePatient(int id)
    {
        logger.LogInformation("Patient with {id} was deleted", id);
        var isDelete = service.DeletePatient(id);
        if (isDelete) return Ok(true);
        return NotFound();
    }
}
