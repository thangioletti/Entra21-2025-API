using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> GetById(int id);

        Task Insert(UserInsertDTO user);

        Task Delete(int id);

        Task Update(UserEntity user);

        Task<UserEntity> Login(UserLoginDTO user);
    }
}
