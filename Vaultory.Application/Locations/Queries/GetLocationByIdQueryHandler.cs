using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Locations;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationDto>
{
    private readonly IVaultoryDbContext _context;

    public GetLocationByIdQueryHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<LocationDto> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Locations.Where(c => c.Id == request.Id && !c.IsDeleted).Select(c => new LocationDto
        {
            Id = c.Id,
            Name = c.Name
        }).FirstOrDefaultAsync();
    }
}