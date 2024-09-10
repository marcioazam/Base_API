﻿using Domain.Aggregates;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.ValueObjects;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TModel> where TModel : class, IEntity
    {
        Task<TReturn?> GetById<TReturn>(long id);

        Task<PagedResult<TReturn>> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize);

        Task<List<TReturn>> List<TReturn, TFilter>(TFilter filter);

        Task<int> Count<TFilter>(TFilter filter);

        Task<bool> Exist<TFilter>(TFilter filter);

        Task<IAutoGeneratedValue> Insert(TModel model);

        void Update(TModel newEntity, TModel oldEntity);

        Task Delete(long id);
    }
}
