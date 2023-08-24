using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetCartList
{
    public class CartListVM
    {
        public IList<CartLookup> Carts { get; set; }
    }
}
