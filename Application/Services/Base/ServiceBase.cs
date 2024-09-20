using Application.Interfaces.Services.Base;
using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Services.Base
{
    public class ServiceBase<TRepository, TModel>(TRepository genericRepository) : IServiceBase where TRepository : IRepositoryBase<TModel>
            where TModel : class, IEntity
    {
        private readonly TRepository _genericRepository = genericRepository;

        public async Task<Result> Count<TFilter>(TFilter filter) => new Result(await _genericRepository.Count(filter), []);

        public async Task<Result> Get<TReturn, TFilter>(TFilter filter) => new Result(await _genericRepository.Get<TReturn, TFilter>(filter), []); 

        public async Task<Result> Exist<TFilter>(TFilter filter) => new Result(await _genericRepository.Exist(filter), []);

        public async Task<Result> GetById<TReturn>(long id)
        {
            var entity = await _genericRepository.GetById<TReturn>(id);

            if (entity != null)
            {
                return new Result(entity, []);
            }
            else
            {
                return new Result(null,
                [
                    new((int)GlobalError.NotFound, "", "", EnumHelper.GetDesc(GlobalError.NotFound))
                ]);
            }
        }

        public async Task<Result> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize) => new Result(await _genericRepository.PagedList<TReturn, TFilter>(filter, pageNumber, pageSize), []);

        public async Task<Result> List<TReturn, TFilter>(TFilter filter) => new Result(await _genericRepository.List<TReturn, TFilter>(filter), []);
    }
}
