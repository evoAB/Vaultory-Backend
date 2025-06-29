using MediatR;
using Vaultory.Application.Auth.DTOs;
using Vaultory.Application.Common.Interfaces;

namespace Vaultory.Application.Auth.Queries;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly IAuthService _authService;
    
    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken) {
        return await _authService.LoginAsync(request.Email, request.Password);
    }
}