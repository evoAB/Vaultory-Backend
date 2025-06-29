using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Locations;

public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, List<LocationDto>>
{
    private readonly IVaultoryDbContext _context;

    public GetAllLocationQueryHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<LocationDto>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Locations.Where(c => !c.IsDeleted)
                            .Select(c => new LocationDto
                            {
                                Id = c.Id,
                                Name = c.Name
                            }).ToListAsync();
    }
}