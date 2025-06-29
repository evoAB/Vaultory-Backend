using MediatR;

namespace Vaultory.Application.Categories;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto>;