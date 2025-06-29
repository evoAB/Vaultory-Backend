using Vaultory.Application.Models;

namespace Vaultory.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(IAppUser user);
}