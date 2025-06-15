using MediatR;

namespace Vaultory.Application.Products.Commands;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;