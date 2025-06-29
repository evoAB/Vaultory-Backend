using MediatR;

namespace Vaultory.Application.Categories;

public record DeleteCategoryCommand(Guid Id) : IRequest<bool>;
