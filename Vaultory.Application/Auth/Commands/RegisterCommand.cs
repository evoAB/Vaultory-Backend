using MediatR;
using Vaultory.Application.Auth.DTOs;

namespace Vaultory.Application.Auth.Commands;

public class RegisterCommand : IRequest<AuthResponse>
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}