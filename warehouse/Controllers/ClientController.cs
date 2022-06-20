using Microsoft.AspNetCore.Mvc;
using warehouse.Creation;
using warehouse.Services;

namespace warehouse.Controllers;

[Route("/api/client")]
public class ClientController:ControllerBase
{
    private readonly ClientService _clientService;

    public ClientController(ClientService clientService)
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
        var result = _clientService.CreateClient(input);
        return Created(result, null);
    }
}