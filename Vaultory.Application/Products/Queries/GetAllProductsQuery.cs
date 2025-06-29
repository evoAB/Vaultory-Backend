using MediatR;
using Vaultory.Application.Common.Models;
using Vaultory.Application.Products.Dtos;

namespace Vaultory.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<PaginatedList<ProductDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Name {get; set;}
    public string? SKU{get; set;}
    public Guid? CategoryId { get; set; }
    public Guid? LocationId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? MinQuantity {get; set;}
    public int? MaxQuantity {get; set;}

    public string? SortBy {get; set;}
    public bool IsDescending{get; set;} = false;
}
