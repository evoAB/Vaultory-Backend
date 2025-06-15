using MediatR;

namespace Vaultory.Application.Products.Commands;

public class UpdateProductCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SKU { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }

//     public UpdateProductCommand(UpdateProductCommand command)
// {
//     this.Id = command.Id;
//     this.Name = command.Name;
//     this.SKU = command.SKU;
//     this.Quantity = command.Quantity;
//     this.Price = command.Price;
// }
}