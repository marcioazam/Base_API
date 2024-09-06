using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.Base
{
    public interface IServiceBase
    {
        Task<TEntity?> Get<TEntity>(Expression<Func<TEntity, bool>> expression);

        Task<PagedResult<TEntity>> PagedList<TEntity>(Expression<Func<TEntity, bool>>? expression, int pageNumber, int pageSize);

        Task<List<TGenericDTO>> List<TGenericDTO>(TGenericDTO expression) where TGenericDTO : class;

        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> expression);

        Task<bool> Exist<TEntity>(Expression<Func<TEntity, bool>> expression);

        Task<TResponse> Post<TResponse>(IRequest<TResponse> command);
    }
}
