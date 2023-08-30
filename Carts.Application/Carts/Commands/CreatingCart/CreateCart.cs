using MediatR;

namespace Carts.Application.Carts.Commands.CreatingCart
{
    public class CreateCart : IRequest<Guid>
    {
        public Guid machineId { get; set; }
        public string Goods { get; set; }
    }
}
