using Vaultory.Domain.Entities;

namespace Vaultory.Domain.Entites;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}