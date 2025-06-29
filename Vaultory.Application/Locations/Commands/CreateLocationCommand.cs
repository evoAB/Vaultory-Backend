using MediatR;

namespace Vaultory.Application.Locations;

public class CreateLocationCommand : IRequest<Guid> {
    public string Name { get; set; } = string.Empty;
}