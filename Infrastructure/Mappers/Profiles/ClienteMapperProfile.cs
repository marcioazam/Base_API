using Application.DTOs.Entities.Supplier;
using Domain.Commands.Cliente;
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
    internal class ClienteMapperProfile : ProfileBase
    {
        public ClienteMapperProfile()
        {
            CreateMap<ClienteTable, Cliente>().ReverseMap();

            CreateMap<ClienteTable, ClienteListDTO>()
                .ForMember(x => x.Sexo, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome)).ReverseMap();

            CreateMap<ClienteInsertCommand, Cliente>()
                .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(x => x.Sexo, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.Endereco, opt => opt.MapFrom(src => src.Endereco));

            CreateMap<ClienteUpdateCommand, Cliente>()
                .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(x => x.Sexo, opt => opt.MapFrom(src => src.Sexo))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(x => x.Endereco, opt => opt.MapFrom(src => src.Endereco));
        }
    }
}
