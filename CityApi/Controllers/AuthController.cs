using System.Threading.Tasks;
using CityApi.Core.Dtos;
using CityApi.Core.Entities;
using CityApi.Services;
using CityApi.Services.CityService;
using Microsoft.AspNetCore.Mvc;

namespace CityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorRepository _author;
        public AuthController(IAuthorRepository author)
        {
            _author=author;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister user)
        {
            var response = await _author.Register(new UserEntity
                { Username = user.UserName }, user.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<int>>> Login(UserLogin user)
        {
            var response = await _author.Login(user.UserName, user.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }

}
