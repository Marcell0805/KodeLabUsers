//using HealthChecks.UI.Client;

using HealthChecks.UI.Client;
using KodeLabUsers.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Serilog;

namespace KodeLabUsers.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/KodeLabUsers/swagger.json", "User Results API");
                setupAction.RoutePrefix = "KodeLabUsers";
            });
        }

        public static void ConfigureSwagger(this ILoggerFactory loggerFactory)
        {
           
        }
    }
}