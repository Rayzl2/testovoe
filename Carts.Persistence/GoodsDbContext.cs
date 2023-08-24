using Carts.Application.Interfaces;
using Carts.Domain;
using Carts.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Persistence
{
    public class GoodsDbContext : DbContext, IGoodsDBContext
    {

        public DbSet<Good> Goods { get; set; }

        public GoodsDbContext(DbContextOptions<GoodsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CartConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
