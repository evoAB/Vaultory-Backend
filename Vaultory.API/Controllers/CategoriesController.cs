using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vaultory.Application.Categories;

namespace Vaultory.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _mediator.Send(new GetAllCategoryQuery());
        return Ok(categories);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetCategoryById(Guid Id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(Id));
        if (category == null) return NotFound();
        return Ok(category);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand createCategoryCommand)
    {
        var categoryId = await _mediator.Send(createCategoryCommand);
        return CreatedAtAction(nameof(GetAll), categoryId);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        if (id != command.Id) return BadRequest("Mismatched category Id");

        var result = await _mediator.Send(command);

        if (!result) return NotFound();

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand(id));
        if (!result) return NotFound();
        return NoContent();
    }
}