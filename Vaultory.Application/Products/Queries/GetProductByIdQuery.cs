using MediatR;
using Vaultory.Application.Products.Dtos;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Products.Queries;

public class GetProductByIdQuery(Guid Id) : IRequest<ProductDto>
{
    public Guid Id { get; set; }
}