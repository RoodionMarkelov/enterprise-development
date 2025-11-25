using Application.Service;
using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for doctors
/// </summary>
/// <param name="service"></param>
/// <param name="logger"></param>
[ApiController]
[Route("[controller]")]
public class DoctorController(DoctorService service, ILogger<DoctorController> logger) : ControllerBase
{
    /// <summary>
    /// Get info about doctors
    /// </summary>
    /// <returns>List of doctors</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Doctor>> Get()
    {
        logger.LogInformation("A list of existing doctors has been obtained");
        return Ok(service.GetAllDoctors());
    }

    /// <summary>
    /// Getting info about doctor by ID
    /// </summary>
    /// <param name="id"> id of doctor</param>
    /// <returns>Doctor with id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Doctor> GetDoctor(int id)
    {
        logger.LogInformation("Getting a doctor with the {id}", id);
        var doctor = service.GetDoctor(id);
        if (doctor != null) return Ok(doctor);

        return NotFound();
    }

    /// <summary>
    /// Creating Doctor
    /// </summary>
    /// <param name="doctor">Entity of doctor without id</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<int> CreateDoctor([FromBody] DoctorDto doctor)
    {
        logger.LogInformation("Creating a doctor with the name {fio}", doctor.Name);
        var id = service.CreateDoctor(doctor);
        return Created($"/doctor/{id}", id);
    }

    /// <summary>
    /// Uptade Doctor if exist
    /// </summary>
    /// <param name="id">Id of doctor</param>
    /// <param name="entity">New info about Doctor</param>
    /// <returns>Entity of doctor or null</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Doctor?> UpdateDoctor(int id, [FromBody] Doctor entity)
    {
        logger.LogInformation("Doctor with {id} was updated", id);
        var doctor = service.UpdateDoctor(id, entity);
        if (doctor != null) return Ok(doctor);
        return NotFound();
    }

    /// <summary>
    /// Delete Doctor
    /// </summary>
    /// <param name="id">Id of doctor</param>
    /// <returns>True if delete</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult<bool> DeleteDoctor(int id)
    {
        logger.LogInformation("Doctor with {id} was deleted", id);
        var isDelete = service.DeleteDoctor(id);
        return NoContent();
    }
}
