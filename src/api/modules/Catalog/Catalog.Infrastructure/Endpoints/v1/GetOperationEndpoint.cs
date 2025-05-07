using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class GetOperationEndpoint
{
    internal static RouteHandlerBuilder MapGetOperationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetOperationRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetOperationEndpoint))
            .WithSummary("gets operation by id")
            .WithDescription("gets operation by id")
            .Produces<OperationResponse>()
            .RequirePermission("Permissions.Operations.View")
            .MapToApiVersion(1);
    }
}
