using System;
using Microsoft.AspNetCore.Identity;

namespace SharpAngular.Models.Entities.SharpAngular.IdentityAuth
{
    public class SharpUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}

