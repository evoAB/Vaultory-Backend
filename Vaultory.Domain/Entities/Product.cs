using Vaultory.Domain.Entities;

namespace Vaultory.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; } = false;

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
}