using Application.Service;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for visits
/// </summary>
/// <param name="service">Visit service instance</param>
/// <param name="logger">Logger instance</param>
[ApiController]
[Route("[controller]")]
public class VisitController(IVisitService service, ILogger<VisitController> logger) : ControllerBase
{
    /// <summary>
    /// Get info about visits 
    /// </summary>
    /// <returns>List of visits</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<VisitDto>>> Get()
    {
        logger.LogInformation("A list of existing visits has been obtained");
        var visits = await service.GetAllVisitsAsync();
        return Ok(visits);
    }

    /// <summary>
    /// Getting info about visit by ID
    /// </summary>
    /// <param name="id">ID of visit</param>
    /// <returns>Visit with id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VisitDto>> GetVisit(int id)
    {
        logger.LogInformation("Getting a visit with the {id}", id);
        var visit = await service.GetVisitAsync(id);
        if (visit != null) return Ok(visit);

        return NotFound();
    }

    /// <summary>
    /// Creating Visit
    /// </summary>
    /// <param name="visit">Entity of visit without id</param>
    /// <returns>Created visit ID</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<int>> CreateVisit([FromBody] VisitDto visit)
    {
        logger.LogInformation("Creating a visit with the cabinet {NumberOfCabinet}", visit.NumberOfCabinet);
        var id = await service.CreateVisitAsync(visit);
        return Created($"/visit/{id}", id);
    }

    /// <summary>
    /// Update Visit if exist
    /// </summary>
    /// <param name="id">Id of visit</param>
    /// <param name="entity">New info about visit</param>
    /// <returns>Entity of visit or null</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VisitDto?>> UpdateVisit(int id, [FromBody] VisitDto entity)
    {
        logger.LogInformation("Visit with {id} was updated", id);
        var visit = await service.UpdateVisitAsync(id, entity);
        if (visit != null) return Ok(visit);
        return NotFound();
    }

    /// <summary>
    /// Delete Visit
    /// </summary>
    /// <param name="id">Id of visit</param>
    /// <returns>No content if deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteVisit(int id)
    {
        logger.LogInformation("Visit with {id} was deleted", id);
        await service.DeleteVisitAsync(id);
        return NoContent();
    }
}