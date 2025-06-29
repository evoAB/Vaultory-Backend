using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Locations;

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, bool>
{
    private readonly IVaultoryDbContext _context;

    public DeleteLocationCommandHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(c => c.Id == request.Id);

        if (location == null) return false;

        location.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}