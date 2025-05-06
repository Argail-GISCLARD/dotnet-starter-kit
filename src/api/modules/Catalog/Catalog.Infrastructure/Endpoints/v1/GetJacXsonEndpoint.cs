using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class GetJacXsonEndpoint
{
    internal static RouteHandlerBuilder MapGetJacXsonEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetJacXsonRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetJacXsonEndpoint))
            .WithSummary("gets jacxson by id")
            .WithDescription("gets jacxson by id")
            .Produces<JacXsonResponse>()
            .RequirePermission("Permissions.JacXsons.View")
            .MapToApiVersion(1);
    }
}
