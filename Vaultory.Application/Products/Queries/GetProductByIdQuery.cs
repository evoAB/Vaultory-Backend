using MediatR;
using Vaultory.Application.Products.Dtos;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;