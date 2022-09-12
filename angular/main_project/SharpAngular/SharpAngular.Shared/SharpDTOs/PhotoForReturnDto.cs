using SharpAngular.Shared.SharpDTOs.CoreDto;

namespace SharpAngular.Shared.SharpDTOs
{
    public class PhotoForReturnDto : BaseDto
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DataAdded { get; set; }
        public bool IsMain { get; set; }
        public int PublicId { get; set; }
    }
}
