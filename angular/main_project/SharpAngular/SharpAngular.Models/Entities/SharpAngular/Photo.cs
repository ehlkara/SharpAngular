using SharpAngular.Models.Entities.Core;

namespace SharpAngular.Models.Entities.SharpAngular
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }
        public string description { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
