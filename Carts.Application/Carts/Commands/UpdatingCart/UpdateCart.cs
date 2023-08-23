using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Carts.Application.Carts.Commands.UpdatingCart
{
    public class UpdateCart : IRequest<Guid>
    {
        public Guid SessionId { get; set; }
        public string Goods { get; set; }
    }
}
