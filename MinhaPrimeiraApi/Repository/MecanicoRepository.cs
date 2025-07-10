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
                               VALUE (@Nome);
                SELECT LAST_INSERT_ID();
            ";

            var result = await _connection.ExecuteScalarAsync(sql, mecanico);            
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

        public async Task<int> createOs(OSInsertDTO os)
        {
            string sql = @"
                INSERT INTO ORDEM_SERVICO (Descricao, DataOrdem, Valor, ClienteId)
                                   VALUES (@Descricao, @DataOrdem, @Valor, @ClienteId);
                SELECT LAST_INSERT_ID();
            ";
            return await _connection.GetConnection().ExecuteScalarAsync<int>(sql, os);
        }

        public async Task createOsPeca(IEnumerable<OSInsertPecaDTO> pecas, int osId)
        {
            foreach (OSInsertPecaDTO peca  in pecas) { 
                string sql = @"
                    INSERT INTO ORDEM_SERVICO_PECA (OrdemServicoId, PecaId, Quantidade, Preco)
                                            VALUES (@OrdemServicoId, @PecaId, @Quantidade, @Preco)
                ";
                await _connection.Execute(sql, new
                {
                    OrdemServicoId = osId,
                    PecaId = peca.PecaId,
                    Quantidade = peca.Quantidade,
                    Preco = peca.Preco
                });
            }

        }
    }
}
