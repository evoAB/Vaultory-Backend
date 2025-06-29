using MediatR;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Locations;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Guid> {
    private readonly IVaultoryDbContext _context;

    public CreateLocationCommandHandler(IVaultoryDbContext context){
        _context = context;
    }

    public async Task<Guid> Handle (CreateLocationCommand request, CancellationToken cancellationToken){
        var location = new Location{
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsDeleted = false,
        };
        
        _context.Locations.Add(location);
        await _context.SaveChangesAsync(cancellationToken);

        return location.Id;
    }
}