namespace Vaultory.Application.Dashboard;

public class CategoryProductCountDto
{
    public string CategoryName { get; set; } = default!;
    public int ProductCount { get; set; }
}

public class LocationProductCountDto
{
    public string LocationName { get; set; } = default!;
    public int ProductCount { get; set; }
}

public class DashboardStatsDto
{
    public int TotalProducts{ get; set; }
    public List<CategoryProductCountDto> ProductsByCategory { get; set; } = new();
    public List<LocationProductCountDto> ProductsByLocation { get; set; } = new();
    public int LowStockCount { get; set; }
}