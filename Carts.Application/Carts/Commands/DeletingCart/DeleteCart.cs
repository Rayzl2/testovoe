using MediatR;

namespace Carts.Application.Carts.Commands.DeletingCart
{
    public class DeleteCart : IRequest<Guid>
    {
        public Guid SessionId { get; set; }
        public Guid machineId { get; set; }
    }
}
