using Carts.Application.Interfaces;
using Carts.Domain;
using Carts.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Carts.Persistence
{
    public class GoodsDbContext : DbContext, IGoodsDBContext
    {

        public DbSet<Good> Goods { get; set; }

        public GoodsDbContext(DbContextOptions<GoodsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GoodConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
