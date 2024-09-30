using Application.DTOs.Entities;
using Domain.Commands.ProdutosCommands;
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
    internal class ProdutoMapperProfile : ProfileBase
    {
        public ProdutoMapperProfile()
        {
            CreateMap<ProdutoTable, Produto>().ReverseMap();

            CreateMap<ProdutoTable, ProdutoListDTO>();

            CreateMap<ProdutoInsertCommand, Produto>();

            //CreateMap<ProdutoUpdateCommand, Produto>();
        }
    }
}
