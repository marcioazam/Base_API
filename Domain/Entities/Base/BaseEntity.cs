using Domain.Abstracts.Command.Base;
using Domain.EnumTypes;
using Domain.ValueObjects.ResultInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Task ExecuteBusinnesRulesAfterOperations<T>(T command) where T : class
        {
            switch (command)
            {
                case BaseInsertCommand:
                    InsertCommandAfterOperation();
                    break;
                case BaseUpdateCommand:
                    UpdateCommandAfterOperation();
                    break;
                case BaseDeleteCommand:
                    DeleteCommandAfterOperation();
                    break;
                default:
                    throw new NotImplementedException("BaseCommand não definido!");
            }

            return Task.CompletedTask;
        }

        private protected virtual void DeleteCommandAfterOperation()
        {
            
        }

        private protected virtual void UpdateCommandAfterOperation()
        {
            
        }

        private protected virtual void InsertCommandAfterOperation()
        {
            
        }

        public Task<Result> ExecuteBusinnesRulesBeforeOperations<T>(T command) where T : class
        {
            Result result = new(null, []);

            switch (command)
            {
                case BaseInsertCommand:
                    result = InsertCommandBeforeOperation(result);
                    break;
                case BaseUpdateCommand:
                    result = UpdateCommandBeforeOperation(result);
                    break;
                case BaseDeleteCommand:
                    result = DeleteCommandBeforeOperation(result);
                    break;
                default:
                    throw new NotImplementedException("BaseCommand não definido!");
            }

            return Task.FromResult(result);
        }

        private protected virtual Result InsertCommandBeforeOperation(Result result)
        {
            return result;
        }

        private protected virtual Result DeleteCommandBeforeOperation(Result result)
        {
            return result;
        }

        private protected virtual Result UpdateCommandBeforeOperation(Result result)
        {
            return result;
        }
    }
}
