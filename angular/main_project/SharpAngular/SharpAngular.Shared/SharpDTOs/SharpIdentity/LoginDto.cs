using System.ComponentModel.DataAnnotations;

namespace SharpAngular.Shared.SharpDTOs.SharpIdentity
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
