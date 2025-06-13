using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Application.Products.Dtos;

namespace Vaultory.Application.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IVaultoryDbContext _context;

    public GetAllProductsQueryHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(p => !p.IsDeleted)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                Quantity = p.Quantity,
                Price = p.Price
            })
            .ToListAsync(cancellationToken);
    }
}