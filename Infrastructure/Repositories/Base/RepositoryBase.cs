﻿using AutoMapper;
using Domain.Aggregates;
using Infrastructure.Context;
using Infrastructure.Repositories.Default;
using Infrastructure.Context.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Base;
using MediatR;
using Domain.Interfaces.Tables;
using Domain.Interfaces.Entities.Base;
using Domain.ValueObjects.ResultInfo;

namespace Infrastructure.Repositories.Base
{
    public class RepositoryBase<TTable, TModel>(DefaultContext context, IMapper mapper) : DefaultRepository<TTable, TModel>(context, mapper), IRepositoryBase<TModel>
        where TTable : class, ITable
        where TModel : class, IEntity
    {
        public async Task<int> Count<TFilter>(TFilter filter) => await GetCountList(filter);

        public async Task<bool> Exist<TFilter>(TFilter filter) => await GetExist(filter);

        public async Task<TReturn?> GetById<TReturn>(long id) => await GetDataById<TReturn>(id);

        public async Task<PagedResult<TReturn>> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize) => await GetPagedList<TReturn, TFilter>(filter, pageNumber, pageSize);

        public async Task<List<TReturn>> List<TReturn, TFilter>(TFilter filter) => await GetFullList<TReturn, TFilter>(filter);

        public async Task<Result> Insert(TModel model) => await InsertData(model);

        public Task<ResultError> Update(TModel model) => UpdateData(model);

        public Task<ResultError> Delete(long id) => DeleteData(id);
    }
}
