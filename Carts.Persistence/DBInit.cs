using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Persistence
{
    public class DBInit
    {
        public static void Init(CartsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
