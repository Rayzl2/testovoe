using Carts.Persistence;

namespace Carts.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            // добавления источника данных
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    // инициализация таблицы корзин
                    var cartsDBContext = serviceProvider.GetRequiredService<CartsDbContext>();
                    DBInit.InitCartsDbContext(cartsDBContext);
                    // инициализация таблицы товаров
                    var goodsDbContext = serviceProvider.GetRequiredService<GoodsDbContext>();
                    DBInit.InitGoodsDbContext(goodsDbContext);

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
