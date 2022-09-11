using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharpAngular.Core.Context;
using SharpAngular.Models.Errors;

namespace SharpAngular.Core.Helpers
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var lawendaContext = scope.ServiceProvider.GetRequiredService<SharpAngularDbContext>())
                {
                    try
                    {
                        lawendaContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        throw new UserFriendlyException((int)ErrorCodes.NotWorkMigrate, ErrorMessages.NotWorkMigrate, ex.Message);
                    }
                }
            }
            return host;
        }
    }
}
