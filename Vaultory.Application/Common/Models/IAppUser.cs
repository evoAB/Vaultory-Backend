namespace Vaultory.Application.Models;

public interface IAppUser
{
    public string Id { get; }
    public string UserName{ get; }
    public string Email{ get; }
}