using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Mecanico;

namespace MinhaPrimeiraApi.Services
{
    public class MecanicoService : IMecanicoService
    {
        public async Task<MessageResponse> Delete(int id)
        {
            MecanicoRepository _repository = new MecanicoRepository();
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Mecanico excluido com sucesso!"
            };
        }

        public async Task<MecanicoGetAllResponse> GetAll()
        {
            MecanicoRepository _repository = new MecanicoRepository();
            return new MecanicoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<MecanicoEntity> GetById(int id)
        {
            MecanicoRepository _repository = new MecanicoRepository();
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(MecanicoInsertDTO mecanico)
        {
            MecanicoRepository _repository = new MecanicoRepository();
            await _repository.Insert(mecanico);
            return new MessageResponse
            {
                Message = "Mecanico inserido com sucesso!"
            };
        }

        public async Task<MessageResponse> Update(MecanicoEntity mecanico)
        {
            MecanicoRepository _repository = new MecanicoRepository();
            await _repository.Update(mecanico);
            return new MessageResponse
            {
                Message = "Mecanico alterado com sucesso!"
            };
        }
    }
}
