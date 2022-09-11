using SharpAngular.Shared.SharpDTOs.CoreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAngular.Shared.SharpDTOs.SharpIdentity
{
    public class LoginResponseDto : BaseDto
    {
        public string FullName { get; set; }
        public string AccessToken { get; set; }
    }
}
