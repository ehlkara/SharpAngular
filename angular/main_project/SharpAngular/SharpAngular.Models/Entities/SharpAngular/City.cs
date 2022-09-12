using SharpAngular.Models.Entities.SharpAngular.IdentityAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharpAngular.Models.Entities.SharpAngular
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public SharpUser User { get; set; }
        [JsonIgnore]
        public List<Photo>? Photos { get; set; } = new List<Photo>();
    }
}
