using Application.Interfaces.UoW;
using Domain.Commands.Base;
using Domain.Interfaces.Entities.Base;
using Domain.ValueObjects.ResultInfo;
using FluentValidation.Results;
using MediatR;

namespace Application.Handlers.Default
{
    public abstract class BaseCommandHandler<TCommand, TResponse, TRepository, TModel>(IUnitOfWork unitOfWork) : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
        where TModel : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public Result result = new(null, []);

        public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);

        public async Task Validate(TModel model)
        {
            ValidationResult validationResult = await model.Validate();

            validationResult.Errors.ToList().ForEach(x => result.Errors.Add(new ResultError(x.PropertyName, x.AttemptedValue?.ToString(), x.ErrorMessage)));
        }

        public async Task<bool> Commit()
        {
            if (result.Failed())
                return false;

            if (await _unitOfWork.Commit())
                return true;

            return false;
        }
    }
}
