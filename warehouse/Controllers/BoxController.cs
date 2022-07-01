using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;
[Route("api/package")]
[Authorize]
public class BoxController:ControllerBase
{
    private readonly IBoxService _boxService;

    public BoxController(IBoxService boxService)
    {
        _boxService = boxService;
    }

    [HttpPost]
    public ActionResult CreateBox([FromQuery] int clientId, [FromBody] CreateBox input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _boxService.Create(clientId, input);
        return result is null ? NotFound() : Created(result, null);
    }
    [Authorize]
    [HttpGet]
    public ActionResult<List<Box>> GetAll()
    {
        var result = _boxService.GetAll();
        return result is null ? NotFound() : Ok(result);
    }
    [AllowAnonymous]
    [HttpGet("{packageId}")]
    public ActionResult<Box> GetById([FromRoute] int packageId)
    {
        var result = _boxService.GetById( packageId);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{packageId}")]
    public ActionResult Delete([FromRoute]int packageId)
    {
        var result = _boxService.Remove(packageId);
        return result ? NoContent() : NotFound();
    }
    /// <summary>
    /// Available values: prepared, in transit, in delivery, delivered
    /// </summary>
    /// <param name="packageId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{packageId}")]
    [Authorize(Roles = "Admin, Employee")]
    public ActionResult ChangeStatus([FromRoute] int packageId, [FromBody] ModifyStatus input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _boxService.ChangeStatus(packageId, input.Status);
        return isUpdated ? NoContent() : Ok();
    }
    
}