using SharpAngular.Shared.SharpDTOs.CoreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAngular.Shared.SharpDTOs
{
    public class CityForListDto : BaseDto
    {
        public string Name { get; set; }
        public string Photos { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
