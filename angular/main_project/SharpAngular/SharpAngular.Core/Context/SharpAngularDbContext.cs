using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharpAngular.Models.Entities.SharpAngular.IdentityAuth;

namespace SharpAngular.Core.Context
{
    public class SharpAngularDbContext : IdentityDbContext<SharpUser, SharpRole, int>
    {
        public SharpAngularDbContext(DbContextOptions<SharpAngularDbContext> dbContext) : base(dbContext)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

