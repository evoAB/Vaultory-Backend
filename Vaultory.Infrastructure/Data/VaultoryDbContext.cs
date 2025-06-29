using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Domain.Entities;
using Vaultory.Infrastructure.Identity;

namespace Vaultory.Infrastructure.Data;

public class VaultoryDbContext : IdentityDbContext<ApplicationUser>, IVaultoryDbContext
{
    public VaultoryDbContext(DbContextOptions<VaultoryDbContext> options) : base(options)
    { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Location> Locations => Set<Location>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.SKU).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Quantity).IsRequired();
            entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            entity.Property(p => p.IsDeleted).HasDefaultValue(false);

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(p => p.Location)
                .WithMany(l => l.Products)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(l => l.Name).IsRequired().HasMaxLength(100);
            entity.Property(p => p.IsDeleted).HasDefaultValue(false);
        });        
    }

}