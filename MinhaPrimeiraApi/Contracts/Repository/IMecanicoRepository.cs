using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Contracts.Repository
{
    public interface IMecanicoRepository
    {
        Task<IEnumerable<MecanicoEntity>> GetAll();

        Task<MecanicoEntity> GetById(int id);

        Task Insert(MecanicoInsertDTO mecanico);

        Task Delete(int id);

        Task Update(MecanicoEntity mecanico);
        Task<int> createOs(OSInsertDTO os);
        Task createOsPeca(IEnumerable<OSInsertPecaDTO> pecas, int osId);
    }
}
