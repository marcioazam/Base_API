using Application.DTOs.Entities;
using Domain.Commands.ClientesCommands;
using Domain.Commands.TokensCommands;
using Domain.Entities;
using Infrastructure.Context.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers.Profiles
{
    internal class TokenMapperProfile : ProfileBase
    {
        public TokenMapperProfile()
        {
            CreateMap<TokenTable, Token>().ReverseMap();

            //CreateMap<TokenTable, TokenDTO>();

            CreateMap<TokenInsertCommand, Token>();

            //CreateMap<TokenUpdateCommand, Token>();
        }
    }
}
