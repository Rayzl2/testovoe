using MediatR;
using System;


namespace Carts.Application.Carts.Queries.GetCartList
{
    public class GetCartList : IRequest<CartListVM>
    {
       // public Guid machineId { get; set; }
    }
}
