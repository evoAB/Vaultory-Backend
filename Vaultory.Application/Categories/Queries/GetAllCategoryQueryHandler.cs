using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Categories;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
{
    private readonly IVaultoryDbContext _context;

    public GetAllCategoryQueryHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _context.Categories.Where(c => !c.IsDeleted)
                            .Select(c => new CategoryDto
                            {
                                Id = c.Id,
                                Name = c.Name
                            }).ToListAsync();
    }
}