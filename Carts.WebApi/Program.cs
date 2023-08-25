using Carts.Persistence;
using FluentValidation;

namespace Carts.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {

                    var cartsDBContext = serviceProvider.GetRequiredService<CartsDbContext>();
                    DBInit.InitCartsDbContext(cartsDBContext);

                }
                catch (Exception ex)
                {

                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}