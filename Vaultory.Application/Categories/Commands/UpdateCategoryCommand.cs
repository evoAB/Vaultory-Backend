using MediatR;

namespace Vaultory.Application.Categories;

public record UpdateCategoryCommand(Guid Id, string Name) : IRequest<bool>;