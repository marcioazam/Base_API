﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Tables;
using Domain.ValueObjects.ResultInfo;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Default
{
    public class DefaultRepository<TTable, TGenericEntity> 
        where TTable : class, ITable
        where TGenericEntity : class, IEntity
    {
        protected readonly DefaultContext DbContext;
        protected readonly DbSet<TTable> DbSet;
        protected readonly IMapper Mapper;

        protected virtual IQueryable<TTable> QueryableEntity => DbSet.AsQueryable();

        public DefaultRepository(DefaultContext context, IMapper mapper)
        {
            DbContext = context;
            Mapper = mapper;
            DbSet = DbContext.Set<TTable>();
        }

        public async Task<List<TReturn>> GetFullList<TReturn, TFilter>(TFilter filter)
        {
            var query = BuildQuery(filter);

            var result = await query.ToListAsync();

            return Mapper.Map<List<TReturn>>(result);
        }

        protected async Task<int> GetCountList<TFilter>(TFilter filter)
        {
            var query = BuildQuery(filter);

            return await query.CountAsync();
        }

        protected async Task<bool> GetExist<TFilter>(TFilter filter)
        {
            var query = BuildQuery(filter);

            return await query.AnyAsync();
        }

        protected async Task<TReturn?> GetDataById<TReturn>(long id)
        {
            // Utilizar metodo FindAsync (Melhor desempenho ao buscar pela PK)
            // Ex: estava buscando local por FirstOrDefault() tempo de 700ms, já FindAsync() tempo de 17ms
            var result = await DbSet.FindAsync(id);

            return Mapper.Map<TReturn>(result);
        }

        public virtual async Task<Result> InsertData(TGenericEntity model)
        {
            List<ResultError> errors = [];

            TTable entity = Mapper.Map<TTable>(model);

            DbContext.Entry(entity).State = EntityState.Added;
            var entry = await DbSet.AddAsync(entity);

            var idValue = new AutoGeneratedValue(() =>
            {
                var primaryKey = entry.Metadata.FindPrimaryKey()?.Properties.FirstOrDefault();

                if (primaryKey != null)
                {
                    var propertyInfo = entry.Entity.GetType().GetProperty(primaryKey.Name);

                    if (propertyInfo != null)
                    {
                        var value = propertyInfo.GetValue(entry.Entity);

                        if (value == null)
                        {
                            throw new InvalidOperationException($"Value for property '{primaryKey.Name}' is null.");
                        }
                        else
                        {
                            return (int)Convert.ChangeType(value, typeof(int));
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Property '{primaryKey.Name}' not found on entity.");
                    }                  
                }
                throw new InvalidOperationException("Primary key not found.");
            });

            return new Result(idValue.Id, errors);
        }

        public virtual async Task<ResultError> UpdateData(TGenericEntity NewEntity)
        {
            var OldEntity = await DbSet.FindAsync(NewEntity.Id); 

            // Não achou
            if (OldEntity == null)
                return new ResultError("Id", NewEntity.Id.ToString(), EnumHelper.GetDesc(Error.NotFound));

            // Atualizar a OldEntity com as informações da NewEntity
            Mapper.Map(NewEntity, OldEntity);

            DbContext.Entry(OldEntity).State = EntityState.Modified;
            DbSet.Update(OldEntity);

            return new ResultError();
        }

        public virtual async Task<ResultError> DeleteData(long id)
        {
            var entity = await DbSet.FindAsync(id);

            // Não achou
            if (entity == null)
                return new ResultError("Id", id.ToString(), EnumHelper.GetDesc(Error.NotFound));

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);

            return new ResultError();
        }

        public async Task<PagedResult<TReturn>> GetPagedList<TReturn, TFilter>(TFilter filter, int pageNumber = 1, int pageSize = 10)
        {
            var query = BuildQuery(filter);

            int totalItemCount = await query.CountAsync();

            var resut = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var items = Mapper.Map<List<TReturn>>(resut);

            return new PagedResult<TReturn>
            {
                Items = items,
                TotalItems = totalItemCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize)
            };
        }

        private IQueryable<TTable> BuildQuery<TFilter>(TFilter filter)
        {
            var parameter = Expression.Parameter(typeof(TTable), "x");
            Expression? body = null;

            foreach (var property in typeof(TFilter).GetProperties())
            {
                var value = property.GetValue(filter);
                if (value != null)
                {
                    // Comparação direta entre o valor do filtro e o campo correspondente de TTable
                    var propertyExpression = Expression.Property(parameter, property.Name);
                    var constant = Expression.Constant(value);

                    // Ajusta para 'Contains' caso seja string, ou 'Equal' caso contrário
                    Expression comparison;
                    if (property.PropertyType == typeof(string))
                    {
                        comparison = Expression.Call(propertyExpression, "Contains", null, constant);
                    }
                    else
                    {
                        comparison = Expression.Equal(propertyExpression, constant);
                    }

                    body = body == null ? comparison : Expression.AndAlso(body, comparison);
                }
            }

            var where = body == null ? x => true : Expression.Lambda<Func<TTable, bool>>(body, parameter);

            var query = QueryableEntity;

            if (filter != null)
            {
                query = query.Where(where);
            }

            return query;
        }
    }

    public class AutoGeneratedValue : IAutoGeneratedValue
    {
        private readonly Func<long> primaryKey;

        public AutoGeneratedValue(Func<long> primaryKeyFunc)
        {
            primaryKey = primaryKeyFunc;
        }

        public long Id => primaryKey?.Invoke() ?? 0;

        public override int GetHashCode()
        {
            return HashCode.Combine(primaryKey);
        }
    }
}
