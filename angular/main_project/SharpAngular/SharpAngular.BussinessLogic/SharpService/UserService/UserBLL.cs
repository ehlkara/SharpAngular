using AutoMapper;
using SharpAngular.BussinessLogic.Abstract.IUserBLL;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Shared.SharpDTOs.SharpIdentity;

namespace SharpAngular.BussinessLogic.SharpService.UserService
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        private readonly IMapper _mapper;

        public UserBLL(IMapper mapper, IUserDAL userDAL)
        {
            _mapper = mapper;
            _userDAL = userDAL;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userDAL.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<LoginResponseDto> Login(LoginDto request)
        {
            var userLogin = await _userDAL.Login(request);
            return userLogin;
        }

        public async Task<bool> Register(RegisterDto request)
        {
            return await _userDAL.Register(request);
        }
    }
}
