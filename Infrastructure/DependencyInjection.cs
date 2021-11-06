using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
         public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DefaultConnection"];
            services.AddDbContext<PortalContext>(options => {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IPortalContext>(provider => provider.GetService<PortalContext>());
            
            return services;
        }

    }
}