using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Mecanico;

namespace MinhaPrimeiraApi.Contracts.Service
{
    public interface IMecanicoService
    {
        Task<MessageResponse> Delete(int id);
        Task<MecanicoGetAllResponse> GetAll();
        Task<MecanicoEntity> GetById(int id);
        Task<MessageResponse> Post(MecanicoInsertDTO mecanico);
        Task<MessageResponse> PostOs(OSInsertDTO os);
        Task<MessageResponse> Update(MecanicoEntity mecanico);
    }
}
