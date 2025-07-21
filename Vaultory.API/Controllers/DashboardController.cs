using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vaultory.Application.Dashboard;
using Vaultory.Application.Dashboard.Queries;

namespace Vaultory.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("stats")]
    public async Task<ActionResult<DashboardStatsDto>> GetStats([FromQuery] int LowStockThreshold = 5) {
        var result = await _mediator.Send(new GetDashboardStatsQuery
        {
            LowStockThreshold = LowStockThreshold
        });

        return Ok(result);
    } 
    [HttpGet("analytics")]
    public async Task<ActionResult<
}