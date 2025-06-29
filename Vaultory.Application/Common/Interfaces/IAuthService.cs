using Vaultory.Application.Auth.DTOs;

namespace Vaultory.Application.Common.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(string email, string password, string userName);
    Task<AuthResponse> LoginAsync(string email, string password);
}