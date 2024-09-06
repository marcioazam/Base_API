using Application.Interfaces.UoW;
using Domain.Commands.Base;
using Domain.Interfaces.Entities.Base;
using FluentValidation.Results;
using MediatR;

namespace Application.Handlers.Default
{
    public abstract class BaseCommandHandler<TCommand, TResponse, TRepository, TModel>(IUnitOfWork unitOfWork) : IRequestHandler<TCommand, TResponse>
        where TCommand : IRequest<TResponse>
        where TModel : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        private ValidationResult validationResult = new();

        public abstract Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);

        public async Task Validate(TModel model)
        {
            validationResult = await model.Validate();
        }

        public bool IsInvalid => validationResult.IsValid == false;

        public IList<CommandResultErro> ValidationErrors
        {
            get
            {
                return validationResult.Errors
                        .Select(x => new CommandResultErro(x.PropertyName, x.ErrorMessage))
                        .ToList();
            }
        }

        public async Task<bool> Commit()
        {
            if (IsInvalid)
                return false;

            if (await _unitOfWork.Commit())
                return true;

            return false;
        }
    }
}
