using AutoMapper;
using Carts.Application.Carts.Commands.CreatingCart;
using Carts.Application.Carts.Commands.UpdatingCart;
using Carts.Application.Common.Mapping;

namespace Carts.WebApi.Models
{
    public class UpdateCartDto :IMap<UpdateCart>
    {
       // public Guid SessionId { get; set; }
       // public string Goods { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<UpdateCartDto, UpdateCart>()
               /*.ForMember(cartVM => cartVM.SessionId,
               opt => opt.MapFrom(cart => cart.SessionId))

              .ForMember(cartVM => cartVM.Goods,
              opt => opt.MapFrom(cart => cart.Goods))*/;
        }
    }
}
