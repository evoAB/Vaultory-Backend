using Microsoft.AspNetCore.Identity;
using Vaultory.Application.Models;

namespace Vaultory.Infrastructure.Identity;

public class ApplicationUser : IdentityUser, IAppUser
{
    public bool IsActive { get; set; } = true;

}