using Microsoft.EntityFrameworkCore;
using Vaultory.Domain.Entities;

namespace Vaultory.Application.Common.Interfaces;

public interface IVaultoryDbContext
{
    DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}