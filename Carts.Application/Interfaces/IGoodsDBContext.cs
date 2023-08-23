using Carts.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Interfaces
{
    public interface IGoodsDBContext
    {

        DbSet<Good> Goods { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
