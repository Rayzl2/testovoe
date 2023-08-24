using AutoMapper;
using AutoMapper.QueryableExtensions;
using Carts.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetCartList
{
    public class GetCartListHandler : IRequestHandler<GetCartList, CartListVM>
    {
        private readonly ICartsDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetCartListHandler(ICartsDBContext dBContext, IMapper mapper)
        {
            (_dBContext, _mapper) = (dBContext, mapper);
        }

        public async Task<CartListVM> Handle(GetCartList request, CancellationToken cancellationToken)
        {
            var query = await _dBContext.Carts
                //.Where(cart => cart.machineId == request.machineId)
                .ProjectTo<CartLookup>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CartListVM { Carts = query };

        }
    }
}
