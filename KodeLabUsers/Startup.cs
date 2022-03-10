using System;
using System.IO;
using HealthChecks.UI.Client;
using KodeLabUsers.Domain.Settings;
using KodeLabUsers.Infrastructure.Extension;
using KodeLabUsers.Persistence;
using KodeLabUsers.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Serilog;

namespace KodeLabUsers
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;

        public Startup(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configRoot = builder.Build();

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        private AppSettings AppSettings { get; }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddController();

            services.AddDbContext(Configuration, configRoot);

            

            services.AddAutoMapper();

            services.AddScopedServices();
            //This will implement the interfaces that will be required in the REST services
            services.AddTransientServices();

            services.AddSwaggerOpenAPI();

            services.AddServiceLayer();

            services.AddVersion();

            services.AddFeatureManagement();
            
        }
        public static bool CheckDb()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            return dbContext.Database.CanConnect();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (!CheckDb())
            {
                UpdateDatabase(app);
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                options.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod());

            app.ConfigureCustomExceptionMiddleware();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.ConfigureSwagger();
            app.UseCors(cors => cors
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            try
            {
                context.Database.Migrate();
            }
            catch (Exception)
            {


            }
        }
        
    }
}