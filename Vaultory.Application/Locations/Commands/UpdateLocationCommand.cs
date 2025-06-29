using MediatR;

namespace Vaultory.Application.Locations;

public record UpdateLocationCommand(Guid Id, string Name) : IRequest<bool>;