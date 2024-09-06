using Application.Interfaces.UoW;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using Domain.Interfaces.Repositories;
using MediatR;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Entities.Base;
using AutoMapper;
using Application.Handlers.Default;

namespace Application.Handlers.Bases
{
    public class BaseInsertHandler<TModel, TCommand>(IUnitOfWork unitOfWork, IGenericRepository<TModel> repository, IMapper mapper) : BaseCommandHandler<TCommand, CommandResult, IGenericRepository<TModel>, TModel>(unitOfWork)
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

            var result = await _repository.Insert(entity);

            await Commit();

            return new CommandResult(true, result.Id);
        }
    }
}
