using Carts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Carts.Application.Interfaces
{
    public interface IGoodsDBContext
    {
        // ИНТЕРФЕЙС ТАБЛИЦЫ GOODS
        DbSet<Good> Goods { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
