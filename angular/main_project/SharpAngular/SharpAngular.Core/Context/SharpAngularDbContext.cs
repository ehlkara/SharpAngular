using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharpAngular.Models.Entities.SharpAngular;
using SharpAngular.Models.Entities.SharpAngular.IdentityAuth;

namespace SharpAngular.Core.Context
{
    public class SharpAngularDbContext : IdentityDbContext<SharpUser, SharpRole, int>
    {
        public SharpAngularDbContext(DbContextOptions<SharpAngularDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

