using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Services;

namespace warehouse.Controllers;

/// <summary>
/// Controller to operate on the users
/// </summary>
[Route("api/account")]
[ApiController]
public class AccountController:ControllerBase
{
    private readonly IAccountService _accountService;

    /// <inheritdoc />
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    /// <summary>
    /// Endpoint to register users
    /// </summary>
    /// <param name="input">CreateUser json</param>
    /// <response code="200">Created</response>
    [HttpPost("register")]
    [Consumes("application/json")]
    [ProducesResponseType(200)]
    public ActionResult RegisterUser([FromBody]CreateUser input)
    {
        _accountService.RegisterUser(input);
        return Ok();
    }
    /// <summary>
    /// Endpoint to login user
    /// </summary>
    /// <param name="input">CreateUser json</param>
    /// <response code="200">JWT Token</response>
    [HttpPost("login")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(string), 200)]
    public ActionResult Login([FromBody] LoginUser input)
    {
        var token = _accountService.GenerateJwt(input);
        return Ok(token);
    }
}