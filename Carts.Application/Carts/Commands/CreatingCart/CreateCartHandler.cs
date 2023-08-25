using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Carts.Domain;
using Carts.Application.Interfaces;

namespace Carts.Application.Carts.Commands.CreatingCart 
{
    public class CreateCartHandler : IRequestHandler<CreateCart, Guid>
    {

        private readonly ICartsDBContext _dbContext;
        public CreateCartHandler(ICartsDBContext dbContext) =>
    
            _dbContext = dbContext;
        
        public async Task<Guid> Handle(CreateCart request, CancellationToken cancellationToken)
        {
            var cart = new Cart
            {
                machineId = request.machineId,
                SessionId = Guid.NewGuid(),
                Goods = "Корзина пуста"
            };

            await _dbContext.Carts.AddAsync(cart, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return cart.SessionId;
        }
    }
}
