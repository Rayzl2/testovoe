using MediatR;

namespace Carts.Application.Carts.Commands.UpdatingCart
{
    public class UpdateCart : IRequest<Guid>
    {
        public Guid machineId { get; set; }
        public Guid SessionId { get; set; }
        public string Goods { get; set; }
    }
}
