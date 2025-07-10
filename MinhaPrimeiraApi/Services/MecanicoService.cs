using MinhaPrimeiraApi.Contracts.Repository;
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

        private IMecanicoRepository _repository;

        public MecanicoService(IMecanicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<MessageResponse> Delete(int id)
        {
            await _repository.Delete(id);
            return new MessageResponse
            {
                Message = "Mecanico excluido com sucesso!"
            };
        }

        public async Task<MecanicoGetAllResponse> GetAll()
        {
            return new MecanicoGetAllResponse
            {
                Data = await _repository.GetAll()
            };
        }

        public async Task<MecanicoEntity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<MessageResponse> Post(MecanicoInsertDTO mecanico)
        {
            await _repository.Insert(mecanico);
            return new MessageResponse
            {
                Message = "Mecanico inserido com sucesso!"
            };
        }

        

        public async Task<MessageResponse> Update(MecanicoEntity mecanico)
        {
            await _repository.Update(mecanico);
            return new MessageResponse
            {
                Message = "Mecanico alterado com sucesso!"
            };
        }


        public async Task<MessageResponse> PostOs(OSInsertDTO os)
        {
            var osId = await _repository.createOs(os);

            await _repository.createOsPeca(os.Pecas, osId);
            return new MessageResponse
            {
                Message = "Os criada com sucesso!"
            };

        }
    }
}
