using MediatR;

namespace Vaultory.Application.Categories;

public class CreateCategoryCommand : IRequest<Guid> {
    public string Name { get; set; } = string.Empty;
}