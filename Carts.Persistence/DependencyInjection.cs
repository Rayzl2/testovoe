using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Carts.Application.Interfaces;

namespace Carts.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // определение пути к подключению БД
            var connection = configuration.GetConnectionString("WebApiDatabase");
            
            // ОПРЕДЕЛЕНИЕ КОНФИГУРАЦИИ ДЛЯ ПОДКЛЮЧЕНИЯ К CARTS
            services.AddDbContext<CartsDbContext>(options =>
            {
                options.UseNpgsql(connection);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<ICartsDBContext>(provider => provider.GetService<CartsDbContext>());

            // ОПРЕДЕЛЕНИЕ КОНФИГУРАЦИИ ДЛЯ ПОДКЛЮЧЕНИЯ К GOODS
            services.AddDbContext<GoodsDbContext>(options =>
            {
                options.UseNpgsql(connection);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IGoodsDBContext>(provider => provider.GetService<GoodsDbContext>());

            return services;
        }
    }
}
