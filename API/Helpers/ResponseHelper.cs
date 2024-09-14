﻿using Domain.EnumTypes;
using Domain.Helpers;
using Domain.Interfaces.ValueObjects;
using Domain.ValueObjects.ResultInfo;
using Microsoft.AspNetCore.Mvc;

namespace API.Helpers
{
    public static class ResponseHelper
    {
        public static IActionResult BuildResult(ControllerBase controllerBase, Result result, ResponseStatus responseStatus, string routeGet = "Get")
        {
            responseStatus = VerifyNotFoundOrBadRequest(responseStatus, result);

            switch (responseStatus)
            {
                case ResponseStatus.NoContent:
                    return controllerBase.NoContent();

                case ResponseStatus.Created:
                    if (result.Data is IAutoGeneratedValue autoGenValue)
                    {
                        return controllerBase.CreatedAtAction(routeGet, new { id = autoGenValue.Id }, autoGenValue.Id);
                    }
                    return controllerBase.BadRequest("Data de criação inválida.");

                case ResponseStatus.Ok:
                    return controllerBase.Ok(result.Data);

                case ResponseStatus.BadRequest:
                    return controllerBase.BadRequest(result.Errors);

                case ResponseStatus.NotFound:
                    return controllerBase.NotFound(result.Errors);

                case ResponseStatus.Unauthorized:
                    return controllerBase.Unauthorized(result.Errors);

                default:
                    return controllerBase.Ok(result.Data);
            }
        }

        private static ResponseStatus VerifyNotFoundOrBadRequest(ResponseStatus responseStatus, Result result)
        {
            foreach (var resultError in result.Errors)
            {
                if (resultError.Message == EnumHelper.GetDesc(ErrorMessage.NotFound))
                {
                    responseStatus = ResponseStatus.NotFound;
                }
                else if(resultError.Message == EnumHelper.GetDesc(ErrorMessage.Unauthorized))
                {
                    responseStatus = ResponseStatus.Unauthorized;
                }
                else
                {
                    responseStatus = ResponseStatus.BadRequest;
                }
            }

            return responseStatus;
        }
    }
}
