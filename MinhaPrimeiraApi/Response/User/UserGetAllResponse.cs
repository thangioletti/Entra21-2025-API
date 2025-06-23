using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Response.User
{
    public class UserGetAllResponse
    {
        public IEnumerable<UserEntity> Data { get; set; }

    }
}
