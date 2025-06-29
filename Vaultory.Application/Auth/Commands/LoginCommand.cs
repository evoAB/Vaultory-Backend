using MediatR;
using Vaultory.Application.Auth.DTOs;

namespace Vaultory.Application.Auth.Queries;

public class LoginCommand : IRequest<AuthResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}