using Carts.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Carts.Application.Common.Exceptions;
using Carts.Domain;

namespace Carts.Application.Carts.Queries.GetCartDetails
{
    public class GetCartDetailsHandler : IRequest<GetCartDetails>
    {

        private readonly ICartsDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetCartDetailsHandler(ICartsDBContext dbContext, IMapper mapper)
        {
            (_dbContext, _mapper) = (dbContext, mapper);
        }

        public async Task<CartDetailsVM> Handle(GetCartDetails request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Carts.FirstOrDefaultAsync(cart => cart.SessionId == request.SessionId);

            if (entity == null)
            {
                throw new NotFound(nameof(Cart), request.SessionId);
            }

            return _mapper.Map<CartDetailsVM>(entity);
        }
    }
}
