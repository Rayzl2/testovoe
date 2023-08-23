using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Carts.Application.Interfaces;
using Carts.Persistence.EntityTypeConfiguration;
using Carts.Domain;

namespace Carts.Persistence
{
    public class CartsDbContext : DbContext, ICartsDBContext
    {

        public DbSet<Cart> Carts { get; set; }

        public CartsDbContext(DbContextOptions<CartsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CartConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
