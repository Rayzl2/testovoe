using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetCartDetails
{
    public class GetCartDetails : IRequest<CartDetailsVM>
    {
        public Guid SessionId { get; set; }
        public string Goods { get; set; }
    }
}
