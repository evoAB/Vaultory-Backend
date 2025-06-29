using MediatR;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid> {
    private readonly IVaultoryDbContext _context;

    public CreateCategoryCommandHandler(IVaultoryDbContext context){
        _context = context;
    }

    public async Task<Guid> Handle (CreateCategoryCommand request, CancellationToken cancellationToken){
        var category = new Category{
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsDeleted = false
        };
        
        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}