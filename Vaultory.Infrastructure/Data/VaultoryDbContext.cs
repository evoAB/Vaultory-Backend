using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Domain.Entities;

namespace Vaultory.Infrastructure.Data;

public class VaultoryDbContext : DbContext, IVaultoryDbContext
{
    public VaultoryDbContext(DbContextOptions<VaultoryDbContext> options) : base(options)
    { }
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>{
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.SKU).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Quantity).IsRequired();
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            entity.Property(p => p.IsDeleted).HasDefaultValue(false);
        });
    }

}