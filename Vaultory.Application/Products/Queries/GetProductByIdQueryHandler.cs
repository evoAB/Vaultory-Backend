using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Application.Products.Dtos;

namespace Vaultory.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IVaultoryDbContext _context;

    public GetProductByIdQueryHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Where(p => p.Id == request.Id && !p.IsDeleted)
            .FirstOrDefaultAsync();

        if (product == null) return null;

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            SKU = product.SKU,
            Quantity = product.Quantity,
            Price = product.Price
        };
    }
}