using AutoMapper;
using Carts.Application.Carts.Queries.GetCartDetails;
using Carts.Application.Common.Mapping;
using Carts.Domain;


namespace Carts.Application.Carts.Queries.GetCartList
{
    public class CartLookup : IMap<Cart>
    {
        public Guid SessionId { get; set; }
        public string Goods { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cart, CartLookup>()
                .ForMember(cart => cart.SessionId, opt => opt.MapFrom(optCart => optCart.SessionId))
                .ForMember(cart => cart.Goods, opt => opt.MapFrom(optCart => optCart.Goods));
        }
    }
}
