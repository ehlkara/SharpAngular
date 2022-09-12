using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpAngular.Shared.SharpDTOs
{
    public class PhotoCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public DateTime DataAdded { get; set; } = DateTime.Now;
        public string PublicId { get; set; }
    }
}
