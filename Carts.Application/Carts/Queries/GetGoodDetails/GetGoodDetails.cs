using Carts.Application.Carts.Queries.GetCartDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetGoodDetails
{
    public class GetGoodDetails : IRequest<GoodDetailsVM>
    {
        public Guid GoodId { get; set; }
        public string GoodName { get; set; }
        public string GoodImg { get; set; }
        public int GoodPrice { get; set; }
    }
}
