using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SharpAngular.DataAccess.Abstract;
using SharpAngular.Models.Entities.SharpAngular.IdentityAuth;
using SharpAngular.Shared.SharpDTOs.SharpIdentity;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using SharpAngular.Models.Errors;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace SharpAngular.DataAccess.Concrete
{
    public class UserDAL : IUserDAL
    {
        private readonly UserManager<SharpUser> _sharpUser;
        private readonly IConfiguration _configuration;

        public UserDAL(UserManager<SharpUser> sharpUser, IConfiguration configuration)
        {
            _sharpUser = sharpUser;
            _configuration = configuration;
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _sharpUser.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    FullName = user.Name + " " + user.Surname,
                };
                return userDto;
            }
            else
            {
                throw new UserFriendlyException((int)ErrorCodes.UserNotFound, ErrorMessages.UserNotFound);
            }
        }

        public async Task<LoginResponseDto> Login(LoginDto request)
        {
            var user = await _sharpUser.FindByNameAsync(request.UserName);
            if (user == null)
                throw new UserFriendlyException((int)ErrorCodes.UserNotFound, ErrorMessages.UserNotFound);
            if (user != null && await _sharpUser.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _sharpUser.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256));

                return (new LoginResponseDto()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                    FullName = user.Name + " " + user.Surname,
                    Id = user.Id
                });
            }
            else
            {
                throw new UserFriendlyException((int)ErrorCodes.UserOrPasswordWrong, ErrorMessages.UserOrPasswordWrong);
            }
        }

        public async Task<bool> Register(RegisterDto request)
        {
            var userExists = await _sharpUser.FindByNameAsync(request.Username);
            if (userExists != null)
                throw new UserFriendlyException((int)ErrorCodes.UserAlreadyExist, ErrorMessages.UserAlreadyExist);

            SharpUser user = new SharpUser()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username,
                Name = request.Name,
                Surname = request.Surname
            };
            var result = await _sharpUser.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new UserFriendlyException((int)ErrorCodes.UserCannotCreate, ErrorMessages.UserCannotCreate);
            return true;
        }
    }
}
