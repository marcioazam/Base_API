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
        public Task ExecuteBusinnesRulesAfterOperations(TypeCommand insertCommand)
        {
            switch (insertCommand)
            {
                case TypeCommand.Insert:
                    InsertCommandAfterOperation();
                    break;
                case TypeCommand.Update:
                    UpdateCommandAfterOperation();
                    break;
                case TypeCommand.Delete:
                    DeleteCommandAfterOperation();
                    break;
                default:
                    throw new NotImplementedException("TypeCommand não definido!");
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

        public Task<Result> ExecuteBusinnesRulesBeforeOperations(TypeCommand insertCommand)
        {
            Result result = new(null, []);

            switch (insertCommand)
            {
                case TypeCommand.Insert:
                    result = InsertCommandBeforeOperation(result);
                    break;
                case TypeCommand.Update:
                    result = UpdateCommandBeforeOperation(result);
                    break;
                case TypeCommand.Delete:
                    result = DeleteCommandBeforeOperation(result);
                    break;
                default:
                    throw new NotImplementedException("TypeCommand não definido!");
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
