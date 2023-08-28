using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Carts.Domain;
using Npgsql;


namespace Carts.Persistence.EntityTypeConfiguration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
      public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(cart => cart.machineId);
            builder.HasIndex(cart => cart.machineId);
            builder.Property(cart => cart.SessionId);
            builder.Property(cart => cart.Goods);

        }
    }

}
