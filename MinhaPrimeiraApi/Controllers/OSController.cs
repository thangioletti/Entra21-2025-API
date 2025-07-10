using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Response;

namespace MinhaPrimeiraApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OSController: ControllerBase
    {
        private IMecanicoService _service;
        public OSController(IMecanicoService service) { 
            _service = service;
        }

        [HttpPost]        
        public async Task<ActionResult<MessageResponse>> Post(OSInsertDTO os)
        {
            return Ok(await _service.PostOs(os));
        }
    }
}
