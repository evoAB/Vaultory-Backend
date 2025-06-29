using MediatR;

namespace Vaultory.Application.Categories;

public class GetAllCategoryQuery : IRequest<List<CategoryDto>>;