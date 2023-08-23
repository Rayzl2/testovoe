using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Carts.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Carts.Application.Common.Exceptions;
using Carts.Domain;

namespace Carts.Application.Carts.Commands.UpdatingCart
{
    
    public class UpdateCartHandler : IRequest<UpdateCart>
    {

        public readonly ICartsDBContext _dbContext;
        public UpdateCartHandler(ICartsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCart request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Carts.FirstOrDefaultAsync(cart => cart.SessionId == request.SessionId, cancellationToken);

            if(entity == null)
            {
                throw new NotFound(nameof(Cart), request.SessionId);
            }

            entity.Goods = request.Goods;

            return Unit.Value; 

        }
    }
}
