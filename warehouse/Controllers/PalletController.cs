using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;
/// <summary>
/// Controller for operating on Pallets
/// </summary>
[Route("api/pallet")]
[Authorize]
public class PalletController:ControllerBase
{
    private readonly IPalletService _palletService;

    /// <inheritdoc />
    public PalletController(IPalletService palletService)
    {
        _palletService = palletService;
    }

    /// <summary>
    /// Create pallet
    /// </summary>
    /// <param name="input">CreatePallet, json</param>
    /// <response code="200">Pallet created</response>
    /// <response code="404">Box not found</response>
    /// <response code="400">Bad input format</response>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    [ProducesResponseType(typeof(string),201)]
    public ActionResult CreatePallet([FromBody] CreatePallet input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _palletService.Create(input);
        return result is null ? NotFound() : Created(result, null);
    }

    /// <summary>
    /// Get pallets list
    /// </summary>
    /// <response code="200">List of pallets, json"</response>
    /// <response code="404">Not found</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Pallet>), 200)]
    [ProducesResponseType(404)]
    public ActionResult<List<Pallet>> GetAll()
    {
        var result = _palletService.GetAll();
        return result is null ? NotFound() : Ok(result);
    }
    
    /// <summary>
    /// Get pallet by <paramref name="palletId"/>
    /// </summary>
    /// <param name="palletId"></param>
    /// <response code="200">Pallet, json"</response>
    /// <response code="404">Not found</response>
    [AllowAnonymous]
    [HttpGet("{palletId}")]
    [ProducesResponseType(typeof(Pallet),200)]
    [ProducesResponseType(404)]
    public ActionResult<Pallet> GetById([FromRoute] int palletId)
    {
        var result = _palletService.GetById( palletId);
        return result is null ? NotFound() : Ok(result);
    }
    
    /// <summary>
    /// Delete pallet by <paramref name="palletId"/>
    /// </summary>
    /// <param name="palletId">Pallet Id</param>
    /// <response code="204">Pallet deleted"</response>
    /// <response code="404">Pallet not found</response>
    [HttpDelete("{palletId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public ActionResult Delete([FromRoute]int palletId)
    {
        var result = _palletService.Remove(palletId);
        return result ? NoContent() : NotFound();
    }
    /// <summary>
    /// Change pallet status by <paramref name="palletId"/>
    /// </summary>
    /// <remarks>Available values: prepared, in transit, in delivery, delivered</remarks>
    /// <param name="palletId">Pallet id</param>
    /// <param name="input">ModifyStatus, json</param>
    /// <response code="404">Pallet Not found</response>
    /// <response code="204">Pallet status changed</response>
    /// <response code="400">bad input format"</response>
    /// <response code="403">Forbidden</response>
    [HttpPut("{palletId}")]
    [Authorize(Roles = "Admin, Employee")]
    [Consumes("application/json")]
    [ProducesResponseType(404)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
        
    public ActionResult ChangeStatus([FromRoute] int palletId, [FromBody] ModifyStatus input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _palletService.ChangeStatus(palletId, input.Status);
        return isUpdated ? NoContent() : NotFound();
    }
}