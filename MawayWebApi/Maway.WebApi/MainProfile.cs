using AutoMapper;
using Maway.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maway.BusinessLogic.QueryData;
using Maway.Data.Model.Supplements;

namespace Maway.WebApi
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<ItemType, ItemQueryData>();

            CreateMap<ItemType, ItemAttributesQueryData>()
                .ForMember(x => x.ItemTypeAttributes, x => x.MapFrom(y => y.ItemAttributes))
                .ForMember(x => x.ItemTypeId, x => x.MapFrom(y => y.Id));

            CreateMap<ItemAttributes, AttributeQueryData>()
                .ForMember(x => x.Value, x => x.MapFrom(y => y.Value))
                .ForMember(x => x.Key, x => x.MapFrom(y => y.Attribute.Key))
                .ForMember(x => x.Icon, x => x.MapFrom(y => y.Attribute.Icon));

            CreateMap<Extras, ExtrasQueryData>();
        }
    }
}
