using Dapper;
using MinhaPrimeiraApi.Contracts.Infrastructure;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Infrastructure;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace MinhaPrimeiraApi.Repository
{
    public class MecanicoRepository : IMecanicoRepository
    {

        private IConnection _connection;

        public MecanicoRepository(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<MecanicoEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(MecanicoEntity.Id)},
                           NOME AS {nameof(MecanicoEntity.Nome)}
                      FROM MECANICO
                ";

                IEnumerable<MecanicoEntity> mecanicList = await con.QueryAsync<MecanicoEntity>(sql);
                return mecanicList;
            }
        }

        public async Task Insert(MecanicoInsertDTO mecanico)
        {
            string sql = @$"
                INSERT INTO MECANICO (NOME)
                               VALUE (@Nome)            
            ";

            await _connection.Execute(sql, mecanico);
        }


        public async Task Delete(int id)
        {
            string sql = "DELETE FROM MECANICO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<MecanicoEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(MecanicoEntity.Id)},
                           NOME AS {nameof(MecanicoEntity.Nome)} 
                      FROM MECANICO 
                     WHERE ID = @id
                ";

                MecanicoEntity mecanico = await con.QueryFirstAsync<MecanicoEntity>(sql, new { id });
                return mecanico;
            }

        }

        public async Task Update(MecanicoEntity mecanico)
        {
            string sql = @"
                UPDATE MECANICO
                   SET NOME = @Nome
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, mecanico);

        }
    }
}
