using MediatR;

namespace Vaultory.Application.Locations;

public record DeleteLocationCommand(Guid Id) : IRequest<bool>;