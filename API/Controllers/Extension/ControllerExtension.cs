using Domain.Helpers;
using Domain.ValueObjects.ResultInfo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Extension
{
    public static class ControllerExtension
    {
        public static IActionResult BuildResult(this ControllerBase controller, Result result, ResponseStatus responseStatus, string routeGet = "Get")
        {
            //Bad request 400
            if (result.Failed())
            {
                return controller.BadRequest(result.Errors);
            }

            switch (responseStatus)
            {
                case ResponseStatus.NoContent:
                    return controller.NoContent();
                case ResponseStatus.Created:
                    return controller.CreatedAtAction(routeGet, new { id = result.Data }, result.Data);
                case ResponseStatus.Ok:
                    return controller.Ok(result.Data);
                default:
                    return controller.Ok(result.Data);
            }
        }
    }
}
