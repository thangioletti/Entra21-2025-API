using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Contracts.Infrastructure
{
    public interface IAuthentication
    {
        string GenerateToken(UserEntity user);
    }
}
