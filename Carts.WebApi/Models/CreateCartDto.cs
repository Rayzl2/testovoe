using AutoMapper;
using Carts.Application.Carts.Commands.CreatingCart;
using Carts.Application.Carts.Queries.GetCartDetails;
using Carts.Application.Common.Mapping;
using Carts.Domain;

namespace Carts.WebApi.Models
{
    public class CreateCartDto : IMap<CreateCart>
    {

        //public string Goods { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCartDto, CreateCart>()
                /*.ForMember(cart => cart.Goods, 
                opt => opt.MapFrom(cartDto => cartDto.Goods))*/;
                
        }
    }
}
