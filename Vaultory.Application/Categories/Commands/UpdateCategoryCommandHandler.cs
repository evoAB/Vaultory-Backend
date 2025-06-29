using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Categories;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IVaultoryDbContext _context;

    public UpdateCategoryCommandHandler(IVaultoryDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);

        if (category == null) return false;

        category.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return true;

    }
}