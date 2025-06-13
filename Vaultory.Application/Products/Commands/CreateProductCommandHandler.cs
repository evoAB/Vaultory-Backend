using MediatR;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IVaultoryDbContext _context;

    public CreateProductCommandHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            SKU = request.SKU,
            Quantity = request.Quantity,
            Price = request.Price,
            IsDeleted = false
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
} 