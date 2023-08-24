using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Carts.Application.Interfaces;

namespace Carts.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("WebApiDatabase");
            services.AddDbContext<CartsDbContext>(options =>
            {
                options.UseNpgsql(connection);
            });
            services.AddScoped<ICartsDBContext>(provider => provider.GetService<CartsDbContext>());


            services.AddDbContext<GoodsDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
            });
            services.AddScoped<IGoodsDBContext>(provider => provider.GetService<GoodsDbContext>());

            return services;
        }
    }
}
