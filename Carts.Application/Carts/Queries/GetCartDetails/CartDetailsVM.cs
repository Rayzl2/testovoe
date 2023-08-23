using Carts.Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carts.Domain;
using AutoMapper;

namespace Carts.Application.Carts.Queries.GetCartDetails
{
    public class CartDetailsVM : IMap<Cart>
    {
        public Guid SessionId { get; set; }
        public string Goods { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Cart, CartDetailsVM>().ForMember(cartVM => cartVM.Goods,
                opt => opt.MapFrom(cart => cart.Goods));
        }
    }
}
