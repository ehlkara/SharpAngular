using SharpAngular.Shared.SharpDTOs.SharpIdentity;

namespace SharpAngular.BussinessLogic.Abstract.IUserBLL
{
    public interface IUserBLL
    {
        Task<bool> Register(RegisterDto request);
        Task<LoginResponseDto> Login(LoginDto request);
        Task<UserDto> GetUserById(int id);
    }
}
