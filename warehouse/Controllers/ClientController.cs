using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;

/// <summary>
/// Controller for operating on Clients
/// </summary>
[Route("/api/client")]
[Authorize]
public class ClientController:ControllerBase
{
    private readonly IClientService _clientService;

    /// <inheritdoc />
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    
    /// <summary>
    /// Get all Clients
    /// </summary>
    /// <response code="200">Client List, json</response>
    /// <response code="403">Forbidden</response>
    [HttpGet]
    [Authorize(Roles = "Admin, Employee")]
    [ProducesResponseType(typeof(IEnumerable<Client>),200)]
    public ActionResult<IEnumerable<Client>> GetAll()
    {
        return Ok(_clientService.GetAll());
    }

    /// <summary>
    /// Get client by <paramref name="id"/>
    /// </summary>
    /// <param name="id">Client Id</param>
    /// <response code="200">Client, json</response>
    /// <response code="404">Client not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(typeof(Client),200)]
    public ActionResult<Client> GetById([FromRoute] int id)
    {
        var result = _clientService.GetById(id);
        if (result is null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Create client 
    /// </summary>
    /// <param name="input">CreateClient json</param>
    /// <response code="403">Forbidden</response>
    /// <response code="400">Bad input format</response>
    /// <response code="201">Created, URl</response>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(403)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(string),201)]
    public ActionResult CreateClient([FromBody] CreateClient input)
    {
        if (HttpContext.User.IsInRole("User"))
        {
            return Forbid();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _clientService.CreateClient(input);
        return Created(result, null);
    }

    /// <summary>
    /// Delete client of <paramref name="id"/>
    /// </summary>
    /// <param name="id">Client Id</param>
    /// <response code="403">Forbidden</response>
    /// <response code="404">Client not found</response>
    /// <response code="204">Client deleted</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin, Employee")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public ActionResult DeleteClient([FromRoute] int id)
    {
        var isDeleted = _clientService.Delete(id);
        if (isDeleted) return NoContent();
        return NotFound();
    }

    /// <summary>
    /// Update client by <paramref name="id"/>
    /// </summary>
    /// <param name="id">Client Id</param>
    /// <param name="input">ModifyClient, json</param>
    /// <response code="200">Client updated</response>
    [HttpPut("{id}")]
    [Consumes("application/json")]
    [ProducesResponseType(200)]
    public ActionResult Update([FromRoute] int id, [FromBody] ModifyClient input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _clientService.Update(id, input );
        return Ok();
    }
}