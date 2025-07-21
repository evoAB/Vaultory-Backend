using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Dashboard.Queries;

public class GetDashboardStatsQueryHandler : IRequestHandler<GetDashboardStatsQuery, DashboardStatsDto>
{
    private readonly IVaultoryDbContext _context;

    public GetDashboardStatsQueryHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardStatsDto> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
    {
        var totalProducts = await _context.Products.CountAsync(p => !p.IsDeleted, cancellationToken);

        var byCategory = await _context.Products
            .Where(p => !p.IsDeleted)
            .GroupBy(p => p.Category.Name)
            .Select(g => new CategoryProductCountDto
            {
                CategoryName = g.Key,
                ProductCount = g.Count()
            })
            .ToListAsync(cancellationToken);

        var byLocation = await _context.Products
            .Where(p => !p.IsDeleted)
            .GroupBy(p => p.Location.Name)
            .Select(g => new LocationProductCountDto
            {
                LocationName = g.Key,
                ProductCount = g.Count()
            }).ToListAsync(cancellationToken);

        var lowStock = await _context.Products
            .CountAsync(p => !p.IsDeleted && p.Quantity < request.LowStockThreshold, cancellationToken);

        return new DashboardStatsDto
        {
            TotalProducts = totalProducts,
            ProductsByCategory = byCategory,
            ProductsByLocation = byLocation,
            LowStockCount = lowStock
        };
    }
}