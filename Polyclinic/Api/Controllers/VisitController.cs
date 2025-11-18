using Application.Service;
using Application.DTO;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller for visits
/// </summary>
/// <param name="service"></param>
/// <param name="logger"></param>
[ApiController]
[Route("[controller]")]
public class VisitController(VisitService service, ILogger<VisitController> logger) : ControllerBase
{
    /// <summary>
    /// Get info about visits 
    /// </summary>
    /// <returns>List of visits</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Visit>> Get()
    {
        logger.LogInformation("A list of existing visits has been obtained");
        return Ok(service.GetAllVisits());
    }

    /// <summary>
    /// Getting info about visit by ID
    /// </summary>
    /// <param name="id"> id of visit</param>
    /// <returns>Visit with id</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Visit> GetVisit(int id)
    {
        logger.LogInformation("Getting a visit with the {id}", id);
        var visit = service.GetVisit(id);
        if (visit != null) return Ok(visit);

        return NotFound();
    }

    /// <summary>
    /// Creating Visit
    /// </summary>
    /// <param name="visit">Entity of visit without id</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<int> CreateVisit([FromBody] VisitDto visit)
    {
        logger.LogInformation("Creating a visit with the name {NumberOfCabinet}", visit.NumberOfCabinet);
        var id = service.CreateVisit(visit);
        return Created($"/visit/{id}", id);
    }

    /// <summary>
    /// Uptade Visit if exist
    /// </summary>
    /// <param name="id">Id of visit</param>
    /// <param name="entity">New info about visit</param>
    /// <returns>Entity of visit or null</returns>
    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Visit?> UpdateVisit(int id, [FromBody] Visit entity)
    {
        logger.LogInformation("Visit with {id} was updated", id);
        var visit = service.UpdateVisit(id, entity);
        if (visit != null) return Ok(visit);
        return NotFound();
    }

    /// <summary>
    /// Delete Visit
    /// </summary>
    /// <param name="id">Id of visit</param>
    /// <returns>True if delete</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> DeleteVisit(int id)
    {
        logger.LogInformation("Visit with {id} was deleted", id);
        var isDelete = service.DeleteVisit(id);
        if (isDelete) return Ok(true);
        return NotFound();
    }
}
