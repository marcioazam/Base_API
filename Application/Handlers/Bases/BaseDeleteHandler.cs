using Application.Handlers.Default;
using Application.Interfaces.UoW;
using AutoMapper;
using Domain.Commands.Base;
using Domain.Interfaces.Command;
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
    public class BaseDeleteHandler<TModel, TCommand>(IUnitOfWork unitOfWork, IRepositoryBase<TModel> repository) : BaseCommandHandler<TCommand, Result, IRepositoryBase<TModel>, TModel>(unitOfWork)
            where TModel : class, IEntity
            where TCommand : IRequest<Result>, IDeleteCommand
    {
        private readonly IRepositoryBase<TModel> _repository = repository;

        public override async Task<Result> Handle(TCommand command, CancellationToken cancellationToken)
        {
            result.Errors.Add(await _repository.Delete(command.Id));

            if (result.Failed())
            {
                return result;
            }

            await Commit();

            return result;
        }
    }
}
