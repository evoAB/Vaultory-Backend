using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vaultory.Application.Locations;

namespace Vaultory.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var locations = await _mediator.Send(new GetAllLocationQuery());
        return Ok(locations);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetLocationById(Guid Id)
    {
        var location = await _mediator.Send(new GetLocationByIdQuery(Id));
        if (location == null) return NotFound();
        return Ok(location);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationCommand command)
    {
        var locationId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), locationId);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocationCommand command)
    {
        if (id != command.Id) return BadRequest("Mismatched location Id");

        var result = await _mediator.Send(command);

        if (!result) return NotFound();

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteLocationCommand(id));
        if (!result) return NotFound();
        return NoContent();
    }
}