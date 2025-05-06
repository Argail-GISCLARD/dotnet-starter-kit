using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateJacXsonEndpoint
{
    internal static RouteHandlerBuilder MapJacXsonCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateJacXsonCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateJacXsonEndpoint))
            .WithSummary("creates a jacxson")
            .WithDescription("creates a jacxson")
            .Produces<CreateJacXsonResponse>()
            .RequirePermission("Permissions.JacXsons.Create")
            .MapToApiVersion(1);
    }
}
