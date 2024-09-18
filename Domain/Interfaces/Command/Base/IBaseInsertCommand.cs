using Domain.Interfaces.Entities.Base;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Command.Base
{
    public interface IBaseInsertCommand<TEntity> where TEntity : class, IEntity
    {
        public Task<ResultError> ExecuteBusinnesRulesBeforeOperations(TEntity entity);

        public Task<ResultError> ExecuteBusinnesRuleAfterOperations(TEntity entity);
    }
}
