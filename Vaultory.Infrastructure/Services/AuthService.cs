using Microsoft.AspNetCore.Identity;
using Vaultory.Application.Auth.DTOs;
using Vaultory.Application.Common.Interfaces;
using Vaultory.Domain.Entities;

namespace Vaultory.Infrastructure.Identity;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(UserManager<ApplicationUser> userManager,
                       RoleManager<IdentityRole> roleManager,
                       IJwtTokenGenerator jwtTokenGenerator)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse> RegisterAsync(string email, string password, string username)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        if (existingUser is not null)
            throw new Exception("User already exists");

        var user = new ApplicationUser
        {
            UserName = username,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
        }

        if (!await _roleManager.RoleExistsAsync("User"))
            await _roleManager.CreateAsync(new IdentityRole("User"));

        await _userManager.AddToRoleAsync(user, "User");

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResponse { UserId = user.Id, Email = user.Email!, Token = token };
    } 

    public async Task<AuthResponse> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null || !await _userManager.CheckPasswordAsync(user, password))
            throw new Exception("Invalid credentials");

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthResponse { UserId = user.Id, Email = user.Email!, Token = token };
    }
}
