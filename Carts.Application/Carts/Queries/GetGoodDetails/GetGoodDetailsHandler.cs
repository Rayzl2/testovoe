using AutoMapper;
using Carts.Application.Carts.Queries.GetCartDetails;
using Carts.Application.Common.Exceptions;
using Carts.Application.Interfaces;
using Carts.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetGoodDetails
{
    public class GetGoodDetailsHandler : IRequest<GetGoodDetails>
    {
        private readonly IGoodsDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetGoodDetailsHandler(IGoodsDBContext dbContext, IMapper mapper)
        {
            (_dBContext, _mapper) = (dbContext, mapper);
        }

        public async Task<GoodDetailsVM> Handle(GetGoodDetails request, CancellationToken cancellationToken)
        {
            var entity = await _dBContext.Goods.FirstOrDefaultAsync(good => good.GoodId == request.GoodId);

            if (entity == null)
            {
                throw new NotFound(nameof(Good), request.GoodId);
            }

            return _mapper.Map<GoodDetailsVM>(entity);
        }
    }
}
