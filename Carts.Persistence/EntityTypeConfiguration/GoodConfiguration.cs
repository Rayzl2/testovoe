using Carts.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Persistence.EntityTypeConfiguration
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.HasKey(good => good.GoodId);
            builder.HasIndex(good => good.GoodId);
            builder.Property(good => good.GoodPrice);
            builder.Property(good => good.GoodName);
            builder.Property(good => good.GoodImg);

        }
    
    }
}
