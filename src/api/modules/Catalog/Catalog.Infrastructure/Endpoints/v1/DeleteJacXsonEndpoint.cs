using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class DeleteJacXsonEndpoint
{
    internal static RouteHandlerBuilder MapJacXsonDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteJacXsonCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteJacXsonEndpoint))
            .WithSummary("deletes jacxson by id")
            .WithDescription("deletes jacxson by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.JacXsons.Delete")
            .MapToApiVersion(1);
    }
}
