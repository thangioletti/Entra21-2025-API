using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Response.Mecanico;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.User;

namespace MinhaPrimeiraApi.Contracts.Service
{
    public interface IUserService
    {
        Task<MessageResponse> Delete(int id);
        Task<UserGetAllResponse> GetAll();
        Task<UserEntity> GetById(int id);
        Task<MessageResponse> Post(UserInsertDTO mecanico);
        Task<MessageResponse> Update(UserEntity mecanico);

        Task<UserLoginTokenResponse> Login(UserLoginDTO user);

    }
}
