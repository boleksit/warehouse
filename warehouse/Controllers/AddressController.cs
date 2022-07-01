using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;

[Route("api/client/{clientId}/address")]
[Authorize]
public class AddressController:ControllerBase
{
    private readonly IAddressService _service;

    public AddressController(IAddressService service)
    {
        _service = service;
    }
    [HttpGet]
    public ActionResult<List<Address>> GetAll([FromRoute] int clientId)
    {
        var result = _service.GetAllByClientId(clientId);
        return result is null ? NotFound() : Ok(result);
    }
    
    [HttpGet("{addressId}")]
    public ActionResult<Address> GetByAddressId([FromRoute] int clientId, [FromRoute] int addressId)
    {
        var result = _service.GetById(clientId, addressId);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public ActionResult CreateAddress([FromRoute] int clientId, [FromBody] CreateAddress input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _service.Create(clientId, input);
        return result is null ? NotFound() : Created(result, null);
    }

    [HttpDelete]
    public ActionResult DeleteAddress([FromRoute] int clientId)
    {
        var result = _service.RemoveAllByClientId(clientId);
        return result ? NoContent() : NotFound();
    }

    [HttpDelete("{addressId}")]
    public ActionResult DeleteAddress([FromRoute] int clientId, [FromRoute] int addressId)
    {
        var result = _service.RemoveAddressById(clientId, addressId);
        return result ? NoContent() : NotFound();
    }

    [HttpPut("{addressId}")]
    public ActionResult Update([FromRoute] int clientId, [FromRoute] int addressId, [FromBody] ModifyAddress input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _service.UpdateAddressById(clientId, addressId, input);
        return isUpdated ? NoContent() : Ok();
    }
    
}