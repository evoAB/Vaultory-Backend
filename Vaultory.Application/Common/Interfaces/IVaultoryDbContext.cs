using Microsoft.EntityFrameworkCore;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Common.Interfaces;

public interface IVaultoryDbContext
{
    DbSet<Product> Products { get; }
    DbSet<Category> Categories { get; }
    DbSet<Location> Locations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}