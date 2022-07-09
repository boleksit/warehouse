using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using warehouse.Create;
using warehouse.Modify;
using warehouse.Services;

namespace warehouse.Controllers;

/// <summary>
/// Controlelr to operate on the Addresses
/// </summary>
[Route("api/client/{clientId}/address")]
[Authorize]
public class AddressController:ControllerBase
{
    private readonly IAddressService _service;

    /// <inheritdoc />
    public AddressController(IAddressService service)
    {
        _service = service;
    }
    /// <summary>
    /// Get all addresses connected with the client of <paramref name="clientId"/>
    /// </summary>
    /// <param name="clientId">client id</param>
    /// <response code="200">Address list json</response>
    /// <response code="404">Not found</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Address>),200)]
    [ProducesResponseType(404)]
    public ActionResult<List<Address>> GetAll([FromRoute] int clientId)
    {
        var result = _service.GetAllByClientId(clientId);
        return result is null ? NotFound() : Ok(result);
    }
    
    /// <summary>
    /// Get address by id connected with the client
    /// </summary>
    /// <param name="clientId">client id</param>
    /// <param name="addressId">address id</param>
    /// <response code="200">Address json</response>
    /// <response code="404">Not found</response>
    [HttpGet("{addressId}")]
    [ProducesResponseType(404)]
    [ProducesResponseType(typeof(Address),200)]
    public ActionResult<Address> GetByAddressId([FromRoute] int clientId, [FromRoute] int addressId)
    {
        var result = _service.GetById(clientId, addressId);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Create address for client
    /// </summary>
    /// <param name="clientId">client id</param>
    /// <param name="input">CreateAddress json</param>
    /// <response code="201">Created address url</response>
    /// <response code="404">Address not found</response>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(string),201)]
    [ProducesResponseType(404)]
    public ActionResult CreateAddress([FromRoute] int clientId, [FromBody] CreateAddress input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _service.Create(clientId, input);
        return result is null ? NotFound() : Created(result, null);
    }

    /// <summary>
    /// Delete all addresses for <paramref name="clientId"/>
    /// </summary>
    /// <param name="clientId">Client id</param>
    /// <response code="204">Addresses removed</response>
    /// <response code="404">Client not found</response>
    [HttpDelete]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public ActionResult DeleteAddress([FromRoute] int clientId)
    {
        var result = _service.RemoveAllByClientId(clientId);
        return result ? NoContent() : NotFound();
    }

    /// <summary>
    /// Delete address by <paramref name="addressId"/> for <paramref name="clientId"/>
    /// </summary>
    /// <param name="clientId">Client Id</param>
    /// <param name="addressId">Address Id</param>
    /// <response code="204">Address removed</response>
    /// <response code="404">Address not found</response>
    [HttpDelete("{addressId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public ActionResult DeleteAddress([FromRoute] int clientId, [FromRoute] int addressId)
    {
        var result = _service.RemoveAddressById(clientId, addressId);
        return result ? NoContent() : NotFound();
    }

    /// <summary>
    /// Update address by <paramref name="addressId"/> for <paramref name="clientId"/>
    /// </summary>
    /// <param name="clientId">Client Id</param>
    /// <param name="addressId">Address Id</param>
    /// <param name="input">ModifyAddress json</param>
    /// <response code="200">Address modified</response>
    /// <response code="404">Not found</response>
    [HttpPut("{addressId}")]
    [Consumes("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult Update([FromRoute] int clientId, [FromRoute] int addressId, [FromBody] ModifyAddress input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var isUpdated = _service.UpdateAddressById(clientId, addressId, input);
        return isUpdated ? NoContent() : NotFound();
    }
    
}