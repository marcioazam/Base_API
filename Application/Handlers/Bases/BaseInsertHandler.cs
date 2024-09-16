using Application.Interfaces.UoW;
using Domain.Commands.Base;
using Domain.Commands.Supplier;
using Domain.Interfaces.Repositories;
using MediatR;
using Domain.Interfaces.Repositories.Base;
using Domain.Interfaces.Entities.Base;
using AutoMapper;
using Application.Handlers.Default;
using Domain.ValueObjects.ResultInfo;
using Domain.Interfaces.Command.Base;

namespace Application.Handlers.Bases
{
    public class BaseInsertHandler<TModel, TCommand>(IUnitOfWork unitOfWork, IRepositoryBase<TModel> repository, IMapper mapper) : BaseCommandHandler<TCommand, Result, IRepositoryBase<TModel>, TModel>(unitOfWork)
        where TModel : class, IEntity
        where TCommand : IRequest<Result>, IBaseInsertCommand
    {
        private readonly IRepositoryBase<TModel> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public override async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TModel>(_mapper.Map<TModel>(command));

            await Validate(entity);

            if (result.Failed())
                return result;

            await command.ExecuteBusinnesRulesAfterOperations(entity);

            var entityId = await _repository.Insert(entity);

            await Commit();

            await command.ExecuteBusinnesRulesBeforeOperations(entity);

            return new Result(entityId, []);
        }
    }
}
