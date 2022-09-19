using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpAngular.BussinessLogic.Abstract.IUserBLL;
using SharpAngular.Shared.Responses;
using SharpAngular.Shared.SharpDTOs.SharpIdentity;

namespace SharpAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserBLL userBLL, ILogger<UsersController> logger)
        {
            _userBLL = userBLL;
            _logger = logger;
        }

        [HttpPost(template: "register")]
        public async Task<bool> Register([FromBody] RegisterDto request)
        {
            var responseDto = await _userBLL.Register(request);
            return await Task.FromResult(responseDto);
            
        }

        [HttpPost(template: "login")]
        public async Task<LoginResponseDto> Login([FromBody] LoginDto request)
        {

            var responseDto = await _userBLL.Login(request);
            return await Task.FromResult(responseDto);
            
        }

        [HttpPost(template: "get_user_by_id")]
        public async Task<UserDto> GetUserById([FromBody] int id)
        {
            var responseDto = await _userBLL.GetUserById(id);
            return await Task.FromResult(responseDto);
        }
    }
}
