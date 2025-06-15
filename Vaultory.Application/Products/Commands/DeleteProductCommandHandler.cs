using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Products.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IVaultoryDbContext _context;
    public DeleteProductCommandHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null || product.IsDeleted) return false;

        product.IsDeleted = true;
        
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}