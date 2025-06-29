using MediatR;

namespace Vaultory.Application.Locations;

public class GetAllLocationQuery : IRequest<List<LocationDto>>;