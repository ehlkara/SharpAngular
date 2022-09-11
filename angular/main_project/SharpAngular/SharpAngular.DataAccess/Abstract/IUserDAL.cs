using SharpAngular.Shared.SharpDTOs.SharpIdentity;

namespace SharpAngular.DataAccess.Abstract
{
    public interface IUserDAL
    {
        Task<bool> Register(RegisterDto request);
        Task<LoginResponseDto> Login(LoginDto request);
        Task<UserDto> GetUserById(int id);
    }
}
