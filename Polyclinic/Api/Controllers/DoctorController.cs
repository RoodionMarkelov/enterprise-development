using Application.Service;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for doctors
/// </summary>
/// <param name="service">Doctor service instance</param>
/// <param name="logger">Logger instance</param>
[ApiController]
[Route("[controller]")]
public class DoctorController(IDoctorService service, ILogger<DoctorController> logger) : ControllerBase
{
    /// <summary>
    /// Get info about doctors
    /// </summary>
    /// <returns>List of doctors</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DoctorDto>>> Get()
    {
        logger.LogInformation("A list of existing doctors has been obtained");
        var doctors = await service.GetAllDoctorsAsync();
        return Ok(doctors);
    }

    /// <summary>
    /// Getting info about doctor by ID
    /// </summary>
    /// <param name="id">ID of doctor</param>
    /// <returns>Doctor with id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DoctorDto>> GetDoctor(int id)
    {
        logger.LogInformation("Getting a doctor with the {id}", id);
        var doctor = await service.GetDoctorAsync(id);
        if (doctor != null) return Ok(doctor);
        return NotFound();
    }

    /// <summary>
    /// Creating Doctor
    /// </summary>
    /// <param name="doctor">Entity of doctor without id</param>
    /// <returns>Created doctor ID</returns>
    [HttpPost] // Исправлено с Put на Post для создания
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<int>> CreateDoctor([FromBody] DoctorDto doctor)
    {
        logger.LogInformation("Creating a doctor with the name {fio}", doctor.Name);
        var id = await service.CreateDoctorAsync(doctor);
        return Created($"/doctor/{id}", id);
    }

    /// <summary>
    /// Update Doctor if exist
    /// </summary>
    /// <param name="id">Id of doctor</param>
    /// <param name="entity">New info about Doctor</param>
    /// <returns>Entity of doctor or null</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DoctorDto?>> UpdateDoctor(int id, [FromBody] DoctorDto entity)
    {
        logger.LogInformation("Doctor with {id} was updated", id);
        var doctor = await service.UpdateDoctorAsync(id, entity);
        if (doctor != null) return Ok(doctor);
        return NotFound();
    }

    /// <summary>
    /// Delete Doctor
    /// </summary>
    /// <param name="id">Id of doctor</param>
    /// <returns>No content if deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        logger.LogInformation("Doctor with {id} was deleted", id);
        await service.DeleteDoctorAsync(id);
        return NoContent();
    }
}