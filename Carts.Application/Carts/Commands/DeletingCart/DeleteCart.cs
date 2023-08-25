using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Commands.DeletingCart
{
    public class DeleteCart : IRequest<Guid>
    {
        public Guid SessionId { get; set; }
        public Guid machineId { get; set; }
    }
}
