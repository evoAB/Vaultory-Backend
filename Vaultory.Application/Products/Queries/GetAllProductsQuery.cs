using MediatR;
using Vaultory.Application.Products.Dtos;

namespace Vaultory.Application.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;
