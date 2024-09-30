using Application.DTOs.Entities;
using Domain.Commands.ClientesCommands;
using Domain.Entities;
using Infrastructure.Context.Tables;
using Infrastructure.Mappers;
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

            CreateMap<ClienteTable, ClienteListDTO>();

            CreateMap<ClienteInsertCommand, Cliente>();

            CreateMap<ClienteUpdateCommand, Cliente>();
        }
    }
}
