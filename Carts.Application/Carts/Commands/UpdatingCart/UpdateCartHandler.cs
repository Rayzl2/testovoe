using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Carts.Application.Interfaces;
using Carts.Application.Common.Exceptions;
using Carts.Domain;
using Carts.Application.Carts.Commands.UpdatingCart;

namespace Carts.Application.Carts.Commands.UpdatingCart
{
    public class UpdateCartHandler : IRequestHandler<UpdateCart, Guid>
    {
        private readonly ICartsDBContext _dbContext;

        public UpdateCartHandler(ICartsDBContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(UpdateCart request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Carts.FirstOrDefaultAsync(cart =>
                    cart.SessionId == request.SessionId, cancellationToken);

            if (entity == null)
            {
                throw new NotFound(nameof(Cart), request.SessionId);
            }

            Console.WriteLine(entity);
            entity.Goods = request.Goods;
            // Console.WriteLine(entity.Goods);

            _dbContext.Carts.Update(entity);

            await _dbContext.SaveChangesAsync(cancellationToken); // Сохраняем изменения в базе данных

            return request.SessionId; // заглушка
        }
    }
}