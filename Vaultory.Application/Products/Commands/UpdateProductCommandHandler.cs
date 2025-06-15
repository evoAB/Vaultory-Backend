using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Products.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IVaultoryDbContext _context;

    public UpdateProductCommandHandler(IVaultoryDbContext context){
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken){
        var product = await _context.Products.FirstOrDefaultAsync(p=> p.Id == request.Id && !p.IsDeleted, cancellationToken);

        if(product==null) return false;

        product.Name = request.Name;
        product.SKU = request.SKU;
        product.Quantity = request.Quantity;
        product.Price = request.Price;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
    
}