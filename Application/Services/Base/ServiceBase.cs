using Application.Interfaces.Services.Base;
using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.ValueObjects.ResultInfo;
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
    public class ServiceBase<TRepository, TModel>(TRepository genericRepository) : IServiceBase where TRepository : IRepositoryBase<TModel>
        where TModel : class, IEntity
    {
        private readonly TRepository _genericRepository = genericRepository;

        public async Task<int> Count<TFilter>(TFilter filter) => await _genericRepository.Count(filter);

        public async Task<bool> Exist<TFilter>(TFilter filter) => await _genericRepository.Exist(filter);

        public async Task<Result> GetById<TFilter>(long id) 
        {
            await _genericRepository.GetById<TFilter>(id);

            return null;
        }

        public async Task<PagedResult<TReturn>> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize) => await _genericRepository.PagedList<TReturn, TFilter>(filter, pageNumber, pageSize);

        public async Task<List<TReturn>> List<TReturn, TFilter>(TFilter filter) => await _genericRepository.List<TReturn, TFilter>(filter);
    }
}
