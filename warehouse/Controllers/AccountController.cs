using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Services;

namespace warehouse.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController:ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody]CreateUser input)
    {
        _accountService.RegisterUser(input);
        return Ok();
    }
}