using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateJacXsonEndpoint
{
    internal static RouteHandlerBuilder MapJacXsonUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateJacXsonCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateJacXsonEndpoint))
            .WithSummary("update a jacxson")
            .WithDescription("update a jacxson")
            .Produces<UpdateJacXsonResponse>()
            .RequirePermission("Permissions.JacXsons.Update")
            .MapToApiVersion(1);
    }
}
