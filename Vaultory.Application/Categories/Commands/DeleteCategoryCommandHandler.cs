using MediatR;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Categories;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>{
    private readonly IVaultoryDbContext _context;
    
    public DeleteCategoryCommandHandler(IVaultoryDbContext context){
        _context = context;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.Id);

        if(category == null) return false;

        category.IsDeleted = true;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}