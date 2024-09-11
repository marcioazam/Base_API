using Domain.Helpers;
using Domain.ValueObjects.ResultInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IControllerExtension
    {
        IActionResult BuildResult(ControllerBase controller, Result result, ResponseStatus responseStatus, string routeGet = "Get");

        Task<IActionResult> MediatorSend(ControllerBase controller, IRequest<Result> command);
    }
}
