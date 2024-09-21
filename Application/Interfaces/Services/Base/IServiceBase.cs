using Domain.Aggregates;
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

        Task<Result> Get<TReturn, TFilter>(TFilter filter);

        Task<Result> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize);

        Task<Result> List<TReturn, TFilter>(TFilter filter);

        Task<Result> Count<TFilter>(TFilter filter);

        Task<Result> Exist<TFilter>(TFilter filter);
    }
}
