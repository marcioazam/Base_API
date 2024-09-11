﻿using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using Domain.ValueObjects.ResultInfo;
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
        Task<Result> GetById<TEntity>(long id);

        Task<PagedResult<TReturn>> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize);

        Task<List<TReturn>> List<TReturn, TFilter>(TFilter filter);

        Task<int> Count<TFilter>(TFilter filter);

        Task<bool> Exist<TFilter>(TFilter filter);
    }
}
