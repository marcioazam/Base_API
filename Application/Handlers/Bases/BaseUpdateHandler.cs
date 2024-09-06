using Application.Handlers.Default;
using Application.Interfaces.UoW;
using AutoMapper;
using Domain.Commands.Base;
using Domain.Interfaces.Entities.Base;
using Domain.Interfaces.Repositories.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Bases
{
    public class BaseUpdateHandler<TModel, TCommand>(IUnitOfWork unitOfWork, IGenericRepository<TModel> repository, IMapper mapper) : BaseCommandHandler<TCommand, CommandResult, IGenericRepository<TModel>, TModel>(unitOfWork)
        where TModel : class, IEntity
        where TCommand : IRequest<CommandResult>
    {
        private readonly IGenericRepository<TModel> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public override async Task<CommandResult> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TModel>(_mapper.Map<TModel>(command));

            await Validate(entity);

            if (IsInvalid)
                return new CommandResult(false, ValidationErrors);

            var result = await _repository.Update(entity);

            await Commit();

            return new CommandResult(true);
        }
    }
}
