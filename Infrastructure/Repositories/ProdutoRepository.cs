using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context.Tables;
using Infrastructure.Context;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class ProdutoRepository(DefaultContext context, IMapper imapper) : BaseRepository<ProdutoTable, Produto>(context, imapper), IProdutoRepository
    {
    }
}
