using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vaultory.Application.Auth.Commands;
using Vaultory.Application.Auth.Queries;

namespace Vaultory.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCommand command){
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}