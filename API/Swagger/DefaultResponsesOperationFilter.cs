using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

public class DefaultResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Responses == null)
            operation.Responses = new OpenApiResponses();

        operation.Responses.TryAdd("200", new OpenApiResponse
        {
            Description = "Success"
        });

        operation.Responses.TryAdd("204", new OpenApiResponse
        {
            Description = "No Content"
        });

        operation.Responses.TryAdd("400", new OpenApiResponse
        {
            Description = "Bad Request"
        });

        operation.Responses.TryAdd("401", new OpenApiResponse
        {
            Description = "Unauthorized"
        });

        operation.Responses.TryAdd("404", new OpenApiResponse
        {
            Description = "Not Found"
        });

        operation.Responses.TryAdd("500", new OpenApiResponse
        {
            Description = "Internal Server Error"
        });       
    }
}