using Application.Interfaces.Services.Base;
using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Services.Base
{
    public class ServiceBase<TRepository, TModel>(IMediator mediator, TRepository genericRepository) : IServiceBase where TRepository : IGenericRepository<TModel>
        where TModel : class, IEntity
    {
        private readonly IMediator _mediator = mediator;
        private readonly TRepository _genericRepository = genericRepository;

        public async Task<int> Count<TEntity>(Expression<Func<TEntity, bool>>? expression = null)
        {
            return await _genericRepository.Count<TEntity>(expression);
        }

        public async Task<bool> Exist<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            return await _genericRepository.Exist<TEntity>(expression);
        }

        public async Task<TEntity?> Get<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            return await _genericRepository.Get<TEntity>(expression);
        }

        public async Task<PagedResult<TEntity>> PagedList<TEntity>(Expression<Func<TEntity, bool>>? expression, int pageNumber, int pageSize)
        {
            return await _genericRepository.PagedList<TEntity>(expression, pageNumber, pageSize);
        }

        public async Task<List<TGenericDTO>> List<TGenericDTO>(TGenericDTO expression) where TGenericDTO : class 
        {
            return await _genericRepository.List<TGenericDTO>(expression);
        }

        public async Task<TResponse> Post<TResponse>(IRequest<TResponse> command)
        {
            return await _mediator.Send(command);
        }
    }
}
