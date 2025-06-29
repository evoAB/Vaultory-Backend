using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Locations;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, bool>
{
    private readonly IVaultoryDbContext _context;

    public UpdateLocationCommandHandler(IVaultoryDbContext context){
        _context = context;
    }

    public async Task<bool> Handle (UpdateLocationCommand request, CancellationToken cancellationToken ){
        var location = await _context.Locations.FirstOrDefaultAsync(c => c.Id == request.Id);

        if(location == null) return false;

        location.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    
    }
}