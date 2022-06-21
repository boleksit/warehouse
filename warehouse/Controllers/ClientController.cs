using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;

[Route("/api/client")]
public class ClientController:ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Client>> GetAll()
    {
        return Ok(_clientService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Client> GetById([FromRoute] int id)
    {
        var result = _clientService.GetById(id);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult CreateClient([FromBody] CreateClient input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _clientService.CreateClient(input);
        return Created(result, null);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteClient([FromRoute] int id)
    {
        var isDeleted = _clientService.Delete(id);
        if (isDeleted) return NoContent();
        return NotFound();
    }

    [HttpPut("{id}")]
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