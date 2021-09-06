using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace University.Web
{
    public static class Extensions
    {
        public static void MigrationIfNotExist(this IApplicationBuilder app, DbContext context, ILogger<Startup> logger)
        {
            try
            {
                logger.LogInformation("start migration");
                context.Database.Migrate();
                logger.LogInformation("finish migration");
            }
            catch (Exception ex)
            {
                logger.LogInformation("migration failed");
                logger.LogInformation(ex.Message);
            }
        }
    }
}