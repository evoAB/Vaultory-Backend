using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Infrastructure.Data;
using Vaultory.Infrastructure.Identity;

namespace Vaultory.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VaultoryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IVaultoryDbContext>(provider => provider.GetRequiredService<VaultoryDbContext>());

        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    } 
}