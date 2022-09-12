using SharpAngular.Shared.SharpDTOs.CoreDto;

namespace SharpAngular.Shared.SharpDTOs
{
    public class PhotoDto : BaseDto
    {
        public string Url { get; set; }
        public string description { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int CityId { get; set; }
    }
}
