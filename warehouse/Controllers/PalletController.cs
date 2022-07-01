using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;
[Route("api/pallet")]
[Authorize]
public class PalletController:ControllerBase
{
    private readonly IPalletService _palletService;

    public PalletController(IPalletService palletService)
    {
        _palletService = palletService;
    }

    [HttpPost]
    public ActionResult CreatePallet([FromBody] CreatePallet input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _palletService.Create(input);
        return result is null ? NotFound() : Created(result, null);
    }

    [HttpGet]
    public ActionResult<List<Pallet>> GetAll()
    {
        var result = _palletService.GetAll();
        return result is null ? NotFound() : Ok(result);
    }
    [AllowAnonymous]
    [HttpGet("{palletId}")]
    public ActionResult<Box> GetById([FromRoute] int palletId)
    {
        var result = _palletService.GetById( palletId);
        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpDelete("{palletId}")]
    public ActionResult Delete([FromRoute]int palletId)
    {
        var result = _palletService.Remove(palletId);
        return result ? NoContent() : NotFound();
    }
    /// <summary>
    /// Available values: prepared, in transit, in delivery, delivered
    /// </summary>
    /// <param name="palletId"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPut("{palletId}")]
    [Authorize(Roles = "Admin, Employee")]
    public ActionResult ChangeStatus([FromRoute] int palletId, [FromBody] ModifyStatus input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _palletService.ChangeStatus(palletId, input.Status);
        return isUpdated ? NoContent() : Ok();
    }
}