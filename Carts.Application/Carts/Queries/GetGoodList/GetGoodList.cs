using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetGoodList
{
    public class GetGoodList : IRequest<GoodListVM>
    {
        public Guid GoodId { get; set; }
    }
}
