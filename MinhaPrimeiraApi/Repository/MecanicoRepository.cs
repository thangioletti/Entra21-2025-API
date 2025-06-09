using Dapper;
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
        public async Task<IEnumerable<MecanicoEntity>> GetAll()
        {
            Connection _connection = new Connection();
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
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO MECANICO (NOME)
                               VALUE (@Nome)            
            ";

            await _connection.Execute(sql, mecanico);
        }


        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM MECANICO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<MecanicoEntity> GetById(int id)
        {
            Connection _connection = new Connection();
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
            Connection _connection = new Connection();

            string sql = @"
                UPDATE MECANICO
                   SET NOME = @Nome
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, mecanico);

        }
    }
}
