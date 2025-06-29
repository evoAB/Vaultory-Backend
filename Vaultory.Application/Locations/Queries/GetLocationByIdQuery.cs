using MediatR;

namespace Vaultory.Application.Locations;

public record GetLocationByIdQuery(Guid Id) : IRequest<LocationDto>;