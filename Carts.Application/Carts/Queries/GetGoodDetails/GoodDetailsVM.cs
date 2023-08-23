using AutoMapper;
using Carts.Application.Common.Mapping;
using Carts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Application.Carts.Queries.GetGoodDetails
{
    public class GoodDetailsVM : IMap<Good>
    {
        public Guid GoodId { get; set; }
        public string GoodName { get; set; }
        public string GoodImg { get; set; }
        public int GoodPrice { get; set; }

        public void Mapping(Profile profile) {
            profile.CreateMap<Good, GoodDetailsVM>()
                .ForMember(goodVM => goodVM.GoodName,
                opt => opt.MapFrom(good => good.GoodName))

                .ForMember(goodVM => goodVM.GoodImg,
                opt => opt.MapFrom(good => good.GoodImg))

                .ForMember(goodVM => goodVM.GoodPrice,
                opt => opt.MapFrom(good => good.GoodPrice));
        }
    }
}
