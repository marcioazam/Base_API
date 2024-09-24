using Application.Handlers.Default;
using Application.Interfaces.UoW;
using AutoMapper;
using Domain.Abstracts.Command.Base;
using Domain.Entities.Base;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Bases
{
    public class BaseDeleteHandler<TModel, TCommand>(IUnitOfWork unitOfWork, IRepositoryBase<TModel> repository) : BaseCommandHandler<TCommand, Result, IRepositoryBase<TModel>, TModel>(unitOfWork)
            where TModel : EntityBusinessRules, IEntity
            where TCommand : BaseDeleteCommand, IRequest<Result>
    {
        private readonly IRepositoryBase<TModel> _repository = repository;

        public override async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {
            TModel model = Activator.CreateInstance<TModel>();

            result = await model.ExecuteBusinnesRulesBeforeOperations(command);

            try
            {
                await _repository.Delete(command.Id);

                await Commit();
            }
            catch(Exception ex)
            {
                result.AddError(GlobalError.InternalError, command.Id);

                return result;
            }

            await model.ExecuteBusinnesRulesAfterOperations(command);

            return result;
        }
    }
}
