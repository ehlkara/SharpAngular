using SharpAngular.Shared.SharpDTOs.CoreDto;

namespace SharpAngular.Shared.SharpDTOs
{
    public class CityDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
