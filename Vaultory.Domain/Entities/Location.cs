using Vaultory.Domain.Entities;

namespace Vaultory.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}