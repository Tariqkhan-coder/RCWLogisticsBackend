using RCWLogisticsBackend.Interfaces;
using RCWLogisticsBackend.Services;
using RSWLogistics.Helpers;
using RSWLogistics.Interfaces;
using RSWLogistics.Services;
using System.Collections.Generic;

namespace RSWLogistics.ServiceInjections
{
    public static class InjectService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Inject your custom services here
            services.AddScoped<IDriver, DriverService>();
            services.AddScoped<JwtService>();
            services.AddScoped<EmailService>();
            services.AddScoped<IAdmin, AdminService>();



            return services;
        }
    }
}
