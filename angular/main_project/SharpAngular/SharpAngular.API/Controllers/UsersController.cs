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
        public async Task<Response<bool>> Register([FromBody] RegisterDto request)
        {
            try
            {
                var responseDto = await _userBLL.Register(request);
                return await Response<bool>.Run(responseDto, StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<bool>.Catch(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status400BadRequest });
            }
        }

        [HttpPost(template: "login")]
        public async Task<Response<LoginResponseDto>> Login([FromBody] LoginDto request)
        {
            try
            {
                var responseDto = await _userBLL.Login(request);
                return await Response<LoginResponseDto>.Run(responseDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<LoginResponseDto>.Catch(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status400BadRequest });
            }
        }

        [HttpPost(template: "get_user_by_id")]
        public async Task<Response<UserDto>> GetUserById([FromBody] int id)
        {
            try
            {
                var responseDto = await _userBLL.GetUserById(id);
                return await Response<UserDto>.Run(responseDto, StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<UserDto>.Catch(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status404NotFound });
            }
        }
    }
}
