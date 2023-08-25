namespace Carts.Identity.Data
{
    public class DbInit
    {

        public static void Init(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
