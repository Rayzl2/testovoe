using MediatR;
using AutoMapper;
using Carts.Application.Carts.Queries.GetGoodDetails;
using Carts.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Carts.Application.Carts.Queries.GetGoodList
{
    public class GetGoodListHandler : IRequestHandler<GetGoodList, GoodListVM>
    {
        private readonly IGoodsDBContext _dBContext;
        private readonly IMapper _mapper;

        public GetGoodListHandler(IGoodsDBContext dbContext, IMapper mapper)
        {
            (_dBContext, _mapper) = (dbContext, mapper);
        }

        public async Task<GoodListVM> Handle(GetGoodList request, CancellationToken cancellationToken)
        {
            var goodsQuery = await _dBContext.Goods
                .ProjectTo<GoodLookUp>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GoodListVM { Goods = goodsQuery };
        }
    }
}
