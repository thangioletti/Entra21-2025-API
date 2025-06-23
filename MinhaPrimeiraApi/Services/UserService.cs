using MinhaPrimeiraApi.Contracts.Infrastructure;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Infrastructure;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Mecanico;
using MinhaPrimeiraApi.Response.User;

namespace MinhaPrimeiraApi.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _repository;
        private IAuthentication _authentication;

        public UserService(IUserRepository repository, IAuthentication authentication)
        {
            _repository = repository;
            _authentication = authentication;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "User excluido com sucesso!"
            };
        }

        public async Task<UserGetAllResponse> GetAll()
        {
            return new UserGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<UserEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<UserLoginTokenResponse> Login(UserLoginDTO user)
        {
           
                user.Password = Criptografia.Criptografar(user.Password);
                UserEntity newUser = await _repository.Login(user);
                string token = _authentication.GenerateToken(newUser);
                return new UserLoginTokenResponse
                {
                    User = newUser,
                    Token = token
                };
            

        }

        public async Task<MessageResponse> Post(UserInsertDTO user)
        {
            user.Password = Criptografia.Criptografar(user.Password);
            await _repository.Insert(user);
            return new MessageResponse
            {
                Message = "User inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(UserEntity user)
        {
            await _repository.Update(user);
            return new MessageResponse
            {
                Message = "User alterado com sucesso!"
            };
        }
    }
}
