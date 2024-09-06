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

        public async Task<int> Count<TFilter>(TFilter filter) => await _genericRepository.Count(filter);

        public async Task<bool> Exist<TFilter>(TFilter filter) => await _genericRepository.Exist(filter);

        public async Task<TFilter?> GetById<TFilter>(int id) => await _genericRepository.GetById<TFilter>(id);

        public async Task<PagedResult<TReturnDTO>> PagedList<TReturnDTO, TFilter>(TFilter filter, int pageNumber, int pageSize) => await _genericRepository.PagedList<TReturnDTO, TFilter>(filter, pageNumber, pageSize);

        public async Task<List<TReturnDTO>> List<TReturnDTO, TFilter>(TFilter filter) => await _genericRepository.List<TReturnDTO, TFilter>(filter);

        public async Task<TResponse> Post<TResponse>(IRequest<TResponse> command) => await _mediator.Send(command);
    }
}
