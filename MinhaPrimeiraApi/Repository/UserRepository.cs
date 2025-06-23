using Dapper;
using MinhaPrimeiraApi.Contracts.Infrastructure;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MySql.Data.MySqlClient;

namespace MinhaPrimeiraApi.Repository
{
    public class UserRepository : IUserRepository
    {

        private IConnection _connection;

        public UserRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM USER WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(UserEntity.Id)},
                           NAME AS {nameof(UserEntity.Name)},
                           EMAIL AS {nameof(UserEntity.Email)}
                      FROM USER
                ";

                return await con.QueryAsync<UserEntity>(sql);
            }
        }

        public async Task<UserEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(UserEntity.Id)},
                           NAME AS {nameof(UserEntity.Name)},
                           EMAIL AS {nameof(UserEntity.Email)}
                      FROM USER 
                     WHERE ID = @id
                ";
                 
                return await con.QueryFirstAsync<UserEntity>(sql, new { id }); ;
            }

        }

        public async Task Insert(UserInsertDTO user)
        {
            string sql = @$"
                INSERT INTO USER (NAME, EMAIL, PASSWORD)
                               VALUE (@Name, @Email, @Password)            
            ";

            await _connection.Execute(sql, user);
        }

        public async Task<UserEntity> Login(UserLoginDTO user)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(UserEntity.Id)},
                           NAME AS {nameof(UserEntity.Name)},
                           EMAIL AS {nameof(UserEntity.Email)}
                      FROM USER 
                     WHERE EMAIL = @Email AND PASSWORD = @Password
                ";

                return await con.QueryFirstAsync<UserEntity>(sql, user);
            }

        }

        public async Task Update(UserEntity user)
        {
            string sql = @"
                UPDATE USER
                   SET NAME = @Name,
                       EMAIL = @Email,
                       PASSWORD = @Password
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, user);
        }
    }
}
