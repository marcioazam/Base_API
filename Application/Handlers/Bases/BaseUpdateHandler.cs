using Application.Handlers.Default;
using Application.Interfaces.UoW;
using AutoMapper;
using Domain.Abstracts.Command.Base;
using Domain.Entities.Base;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.ValueObjects;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Bases
{
    public class BaseUpdateHandler<TModel, TCommand>(IUnitOfWork unitOfWork, IRepositoryBase<TModel> repository, IMapper mapper) : BaseCommandHandler<TCommand, Result, IRepositoryBase<TModel>, TModel>(unitOfWork)
        where TModel : BaseEntity, IEntity
        where TCommand : BaseUpdateCommand, IRequest<Result>
    {
        private readonly IRepositoryBase<TModel> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public override async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {
            TModel? entity = await MapAndValidate(command);

            if (result.Failed() || entity == null)
                return result;

            result = await ExecuteOperationsDataBaseAndBRs(entity, command);
            
            return result;
        }

        private async Task<Result> ExecuteOperationsDataBaseAndBRs(TModel entity, TCommand command)
        {
            result = await entity.ExecuteBusinnesRulesBeforeOperations(command);

            if (result.Failed())
                return result;

            await InsertIntoBD(entity);

            await entity.ExecuteBusinnesRulesAfterOperations(command);

            return result;
        }

        private async Task InsertIntoBD(TModel entity)
        {
            _repository.Update(entity);

            await Commit();
        }

        private async Task<TModel?> MapAndValidate(TCommand command)
        {
            var entity = await _repository.GetById<TModel>(command.Id);

            // Não achou
            if (entity == null)
            {
                result.AddError(GlobalError.NotFound, "id", command.Id.ToString());

                return entity;
            }

            _mapper.Map(command, entity);

            await Validate(entity);

            return entity;
        }
    }
}
