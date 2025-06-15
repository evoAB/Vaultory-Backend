using Vaultory.Domain.Entities;

namespace Vaultary.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}