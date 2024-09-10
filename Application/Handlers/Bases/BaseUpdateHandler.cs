using Application.Handlers.Default;
using Application.Interfaces.UoW;
using AutoMapper;
using Domain.Commands.Base;
using Domain.EnumTypes;
using Domain.Helpers;
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
        where TCommand : IRequest<Result>
    {
        private readonly IRepositoryBase<TModel> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public override async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {
            var newEntity = _mapper.Map<TModel>(_mapper.Map<TModel>(command));

            await Validate(newEntity);

            if (result.Failed())
                return result;

            var oldEntity = await _repository.GetById<TModel>(newEntity.Id);

            // Não achou
            if (oldEntity == null)
            {
                result.Errors.Add(new ResultError("Id", newEntity.Id.ToString(), EnumHelper.GetDesc(Error.NotFound)));
                return result;
            }

            _repository.Update(newEntity, newEntity);

            await Commit();

            return result;
        }
    }
}
