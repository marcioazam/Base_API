using Application.Interfaces.Services;
using Application.Services.Base;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutoService(IProdutoRepository repository) : ServiceBase<IProdutoRepository, Produto>(repository), IProdutoService
    {
    }
}
