using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Domain
{
    public class Cart
    {
        public Guid SessionId { get; set; }
        public string Goods { get; set; }


    }

    public class Good
    {
        public Guid GoodId { get; set; }
        public string GoodName { get; set; }
        public string GoodImg { get; set; }
        public int GoodPrice { get; set; }
    }
}
