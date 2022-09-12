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
                return await Response<bool>.SuccessAsync(StatusCodes.Status201Created, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<bool>.FailAsync(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status400BadRequest });
            }
        }

        [HttpPost(template: "login")]
        public async Task<Response<LoginResponseDto>> Login([FromBody] LoginDto request)
        {
            try
            {
                var responseDto = await _userBLL.Login(request);
                return await Response<LoginResponseDto>.SuccessAsync(StatusCodes.Status200OK, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<LoginResponseDto>.FailAsync(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status400BadRequest });
            }
        }

        [HttpPost(template: "get_user_by_id")]
        public async Task<Response<UserDto>> GetUserById([FromBody] int id)
        {
            try
            {
                var responseDto = await _userBLL.GetUserById(id);
                return await Response<UserDto>.SuccessAsync(StatusCodes.Status200OK, responseDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return await Response<UserDto>.FailAsync(new ResponseError { Message = ex.Message, StatusCode = StatusCodes.Status404NotFound });
            }
        }
    }
}
