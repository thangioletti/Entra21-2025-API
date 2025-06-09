using MinhaPrimeiraApi.Entity;

namespace MinhaPrimeiraApi.Response.Mecanico
{
    public class MecanicoGetAllResponse
    {
        public IEnumerable<MecanicoEntity> Data { get; set; }
    }
}
