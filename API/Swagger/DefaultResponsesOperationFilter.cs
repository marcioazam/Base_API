using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

public class DefaultResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Responses == null)
            operation.Responses = new OpenApiResponses();

        // Adiciona a resposta 200 padrão
        operation.Responses.TryAdd("200", new OpenApiResponse
        {
            Description = "Success"
        });

        // Você pode adicionar mais respostas padrão aqui, se necessário
        operation.Responses.TryAdd("400", new OpenApiResponse
        {
            Description = "Bad Request"
        });

        operation.Responses.TryAdd("500", new OpenApiResponse
        {
            Description = "Internal Server Error"
        });
    }
}