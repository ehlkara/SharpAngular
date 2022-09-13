using Microsoft.AspNetCore.Http;

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
