﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Aggregates;
using Domain.Commands.Base;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Tables;
using Domain.Interfaces.ValueObjects;
using Domain.ValueObjects;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Repositories.Base
{
    public class BaseRepository<TTable, TGenericEntity> : IRepositoryBase<TGenericEntity>
        where TTable : class, ITable
        where TGenericEntity : class, IEntity
    {
        protected readonly DefaultContext DbContext;
        protected readonly DbSet<TTable> DbSet;
        protected readonly IMapper Mapper;

        protected virtual IQueryable<TTable> QueryableEntity => DbSet.AsQueryable();

        public BaseRepository(DefaultContext context, IMapper mapper)
        {
            DbContext = context;
            Mapper = mapper;
            DbSet = DbContext.Set<TTable>();
        }

        public async Task<TReturn?> GetById<TReturn>(long id)
        {
            // Utilizar metodo FindAsync (Melhor desempenho ao buscar pela PK)
            // Ex: estava buscando local por FirstOrDefault() tempo de 700ms, já FindAsync() tempo de 17ms
            var result = await DbSet.FindAsync(id);

            return Mapper.Map<TReturn>(result);
        }

        public async Task<PagedResult<TReturn>> PagedList<TReturn, TFilter>(TFilter filter, int pageNumber, int pageSize)
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

        public async Task<List<TReturn>> List<TReturn, TFilter>(TFilter filter)
        {
            var query = BuildQuery(filter);

            var result = await query.ToListAsync();

            return Mapper.Map<List<TReturn>>(result);
        }

        public async Task<int> Count<TFilter>(TFilter filter)
        {
            var query = BuildQuery(filter);

            return await query.CountAsync();
        }

        public async Task<bool> Exist<TFilter>(TFilter filter)
        {
            var query = BuildQuery(filter);

            return await query.AnyAsync();
        }

        public async Task<IAutoGeneratedValue> Insert(TGenericEntity model)
        {
            List<ResultError> errors = [];

            TTable entity = Mapper.Map<TTable>(model);

            DbContext.Entry(entity).State = EntityState.Added;
            var entry = await DbSet.AddAsync(entity);

            return new AutoGeneratedValue(() =>
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
        }

        public void Update(TGenericEntity newEntity, TGenericEntity oldEntity)
        {
            // Atualizar a OldEntity com as informações da NewEntity
            Mapper.Map(newEntity, oldEntity);

            TTable entity = Mapper.Map<TTable>(oldEntity);

            DbContext.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }

        public async Task Delete(long id)
        {
            var entity = await GetById<TTable>(id);

            // Não achou
            if (entity == null)
            {
                throw new InvalidOperationException(EnumHelper.GetDesc(Error.NotFound));
            }

            DbContext.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);
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
}
