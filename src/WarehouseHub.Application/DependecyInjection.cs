using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WarehouseHub.Application.Authentication.Login;
using WarehouseHub.Application.Authentication.Register;

namespace WarehouseHub.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddScoped<LoginUserHandler>();
            services.AddScoped<RegisterUserHandler>();

            return services;
        }
        
    }
}
