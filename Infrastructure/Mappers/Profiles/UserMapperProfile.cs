using Application.DTOs.Entities.Supplier;
using Domain.Commands.Supplier;
using Domain.Entities;
using Infrastructure.Context.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers.Profiles
{
    internal class UserMapperProfile : ProfileBase
    {
        public UserMapperProfile()
        {
            //CreateMap<SupplierTable, Supplier>()
            //    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            //    .ForMember(x => x.ApiUrl, opt => opt.MapFrom(src => src.ApiUrl))
            //    .ForMember(x => x.ApiKey, opt => opt.MapFrom(src => src.ApiKey));

            //CreateMap<Supplier, SupplierTable>()
            //    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            //    .ForMember(x => x.ApiUrl, opt => opt.MapFrom(src => src.ApiUrl))
            //    .ForMember(x => x.ApiKey, opt => opt.MapFrom(src => src.ApiKey))
            //    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));

            //CreateMap<SupplierTable, SupplierListDTO>()
            //    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome)).ReverseMap();

            //CreateMap<SupplierInsertCommand, Supplier>()
            //    .ForMember(x => x.ApiUrl, opt => opt.MapFrom(src => src.ApiUrl))
            //    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            //    .ForMember(x => x.ApiKey, opt => opt.MapFrom(src => src.ApiKey));

            //CreateMap<SupplierUpdateCommand, Supplier>()
            //    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(x => x.ApiUrl, opt => opt.MapFrom(src => src.ApiUrl))
            //    .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
            //    .ForMember(x => x.ApiKey, opt => opt.MapFrom(src => src.ApiKey));

            //CreateMap<Supplier, Supplier>();
        }
    }
}
