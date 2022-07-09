using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;
/// <summary>
/// Controller for operating on boxes
/// </summary>
[Route("api/package")]
[Authorize]
public class BoxController:ControllerBase
{
    private readonly IBoxService _boxService;

    /// <inheritdoc />
    public BoxController(IBoxService boxService)
    {
        _boxService = boxService;
    }

    /// <summary>
    /// Create a new box for <paramref name="clientId"/>
    /// </summary>
    /// <param name="clientId">Client Id</param>
    /// <param name="input">CreateBox json</param>
    /// <response code="201">Created, box URL</response>
    /// <response code="404">Client not found</response>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(string),201)]
    [ProducesResponseType(404)]
    public ActionResult CreateBox([FromQuery] int clientId, [FromBody] CreateBox input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _boxService.Create(clientId, input);
        return result is null ? NotFound() : Created(result, null);
    }
    /// <summary>
    /// Get all boxes
    /// </summary>
    /// <response code="200">List of boxes, json</response>
    /// <response code="404">Not found</response>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Box>),200)]
    [ProducesResponseType(404)]
    public ActionResult<List<Box>> GetAll()
    {
        var result = _boxService.GetAll();
        return result is null ? NotFound() : Ok(result);
    }
    /// <summary>
    /// Get box by <paramref name="packageId"/>
    /// </summary>
    /// <param name="packageId">Box id</param>
    /// <response code="200">Box, json</response>
    /// <response code="404">Box not found</response>
    [AllowAnonymous]
    [HttpGet("{packageId}")]
    [ProducesResponseType(typeof(Box),200)]
    [ProducesResponseType(404)]
    public ActionResult<Box> GetById([FromRoute] int packageId)
    {
        var result = _boxService.GetById( packageId);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Delete box by <paramref name="packageId"/>
    /// </summary>
    /// <param name="packageId">Box Id</param>
    /// <response code="204">Box deleted</response>
    /// <response code="404">Box not found</response>
    [HttpDelete("{packageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public ActionResult Delete([FromRoute]int packageId)
    {
        var result = _boxService.Remove(packageId);
        return result ? NoContent() : NotFound();
    }
    /// <summary>
    /// Change box <paramref name="packageId"/> status
    /// </summary>
    /// <remarks> Available values: prepared, in transit, in delivery, delivered </remarks>
    /// <param name="packageId">Box id</param>
    /// <param name="input">ModifyStatus json</param>
    /// <response code="204">Box deleted</response>
    /// <response code="400">Bad input data</response>
    /// <response code="404">Box not found</response>
    
    [HttpPut("{packageId}")]
    [Authorize(Roles = "Admin, Employee")]
    [Authorize(Roles = "Admin, Employee")]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    public ActionResult ChangeStatus([FromRoute] int packageId, [FromBody] ModifyStatus input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _boxService.ChangeStatus(packageId, input.Status);
        return isUpdated ? NoContent() : NotFound();
    }
    
}