using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Service;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Response.Mecanico;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Response.User;
using Microsoft.AspNetCore.Authorization;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Post(UserInsertDTO user)
        {
            return Ok(await _service.Post(user));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<MessageResponse>> Update(UserEntity user)
        {
            return Ok(await _service.Update(user));
        }

        [HttpGet("HandShake")]
        [Authorize]
        public async Task<ActionResult> HandShake()
        {
            return Ok(new { });
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<UserLoginTokenResponse>> Login(UserLoginDTO user)
        {
            try {
                return Ok(await _service.Login(user));
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

    }
}
