using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using warehouse.Database;
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
}