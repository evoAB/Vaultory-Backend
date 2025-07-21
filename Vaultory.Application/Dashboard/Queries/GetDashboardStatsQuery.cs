using MediatR;

namespace Vaultory.Application.Dashboard.Queries;

public class GetDashboardStatsQuery : IRequest<DashboardStatsDto>
{
    public int LowStockThreshold { get; set; } = 5;
}