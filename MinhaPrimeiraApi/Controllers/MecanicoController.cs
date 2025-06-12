using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.Mecanico;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MecanicoController : ControllerBase
    {
        private IMecanicoService _service;

        public MecanicoController(IMecanicoService mecanicoService)
        {
            _service = mecanicoService;
        }

      
        [HttpGet]
        public async Task<ActionResult<MecanicoGetAllResponse>> Get()
        {            
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MecanicoEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(MecanicoInsertDTO mecanico)
        {            
            return Ok(await _service.Post(mecanico));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]

        public async Task<ActionResult<MessageResponse>> Update(MecanicoEntity mecanico)
        {
            return Ok(await _service.Update(mecanico));
        }
    }
}
