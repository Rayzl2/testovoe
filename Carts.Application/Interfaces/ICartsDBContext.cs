using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Carts.Domain;

namespace Carts.Application.Interfaces
{
    public interface ICartsDBContext
    {

        DbSet<Cart> Carts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
