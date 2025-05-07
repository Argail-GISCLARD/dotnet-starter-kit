using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Operations.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateOperationEndpoint
{
    internal static RouteHandlerBuilder MapOperationCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateOperationCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateOperationEndpoint))
            .WithSummary("creates a operation")
            .WithDescription("creates a operation")
            .Produces<CreateOperationResponse>()
            .RequirePermission("Permissions.Operations.Create")
            .MapToApiVersion(1);
    }
}
