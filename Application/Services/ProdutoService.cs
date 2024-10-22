using Application.Interfaces.Services;
using Application.Services.Base;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class ProdutoService(IProdutoRepository repository) : ServiceBase<IProdutoRepository, Produto>(repository), IProdutoService
    {
    }
}
