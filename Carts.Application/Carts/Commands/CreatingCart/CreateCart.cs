using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Commands.CreatingCart
{
    public class CreateCart : IRequest<Guid>
    {
        public Guid SessionId { get; set; }
        public string Goods { get; set; }
    }
}
