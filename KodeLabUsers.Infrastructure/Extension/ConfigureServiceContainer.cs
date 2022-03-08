using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using KodeLabUsers.Domain.Settings;
using KodeLabUsers.Persistence;
using KodeLabUsers.Service.Contract;
using KodeLabUsers.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

namespace KodeLabUsers.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
            IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserStorageDB") ?? configRoot["ConnectionStrings:InMemoryDb"]
                    , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            serviceCollection.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            serviceCollection.AddTransient<IUserDetailsService, UserDetailsService>();
            serviceCollection.AddTransient<IAddressService, AddressService>();

        }


        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "KodeLabUsers",
                    new OpenApiInfo()
                    {
                        Title = "User Results WebAPI",
                        Version = "1",
                        Description = "Through this API you can access user details",
                        Contact = new OpenApiContact()
                        {
                            Email = "marcellvannniekerk@gmail.com",
                            Name = "Marcell van Niekerk",
                            Url = new Uri("https://github.com/Marcell0805")
                        }
                    });
                var filePath = Path.Combine(AppContext.BaseDirectory, "KodeLabUsers.Infrastructure.xml");
                setupAction.IncludeXmlComments(filePath, includeControllerXmlComments: true);
            });
        }

       
        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}