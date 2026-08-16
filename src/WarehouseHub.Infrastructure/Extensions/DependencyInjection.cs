using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WarehouseHub.Application.Abstractions.Persistence;
using WarehouseHub.Infrastructure.Persistence;
using WarehouseHub.Infrastructure.Authentication;
using WarehouseHub.Application.Abstractions.Authentication;
namespace WarehouseHub.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<WarehouseHubDbContext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("WarehouseHubDb"));
            });
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<WarehouseHubDbContext>());
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenService, JwtTokenService>();
            return services;
        }
    }
}
