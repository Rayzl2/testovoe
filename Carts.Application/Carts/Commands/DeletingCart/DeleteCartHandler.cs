using Carts.Application.Common.Exceptions;
using Carts.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carts.Domain;

namespace Carts.Application.Carts.Commands.DeletingCart
{
    public class DeleteCartHandler : IRequest<DeleteCart>
    {
        private readonly ICartsDBContext _dbContext;
        public DeleteCartHandler(ICartsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteCart request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Carts.FindAsync(new object[] { request.SessionId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFound(nameof(Cart), request.SessionId);
            }

            _dbContext.Carts.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
