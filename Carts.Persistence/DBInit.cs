namespace Carts.Persistence
{
    public class DBInit
    {

        // ПОДКЛЮЧЕНИЕ К ТАБЛИЦЕ CARTS
        public static void InitCartsDbContext(CartsDbContext context)
        {
            context.Database.EnsureCreated();
        }

        // ПОДКЛЮЧЕНИЕ К ТАБЛИЦЕ GOODS
        public static void InitGoodsDbContext(GoodsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
