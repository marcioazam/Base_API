using Application.Handlers.Default;
using Application.Interfaces.UoW;
using AutoMapper;
using Domain.Commands.Base;
using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.Command.Base;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
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
        where TModel : class, IEntity
        where TCommand : IRequest<Result>, IBaseUpdateCommand
    {
        private readonly IRepositoryBase<TModel> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public override async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {   
            var entity = await _repository.GetById<TModel>(command.Id);

            // Não achou
            if (entity == null)
            {
                result.AddError(GlobalError.NotFound, "id", command.Id.ToString());
                return result;
            }

            _mapper.Map(command, entity);

            await Validate(entity);

            if (result.Failed())
                return result;

            _repository.Update(entity);

            await Commit();

            return result;
        }
    }
}
