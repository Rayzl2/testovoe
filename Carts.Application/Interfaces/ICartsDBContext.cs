using Microsoft.EntityFrameworkCore;
using Carts.Domain;

namespace Carts.Application.Interfaces
{
    public interface ICartsDBContext
    {
        // ИНТЕРФЕЙС ТАБЛИЦЫ CARTS
        DbSet<Cart> Carts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
