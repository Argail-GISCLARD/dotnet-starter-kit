using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Operations.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class DeleteOperationEndpoint
{
    internal static RouteHandlerBuilder MapOperationDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteOperationCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteOperationEndpoint))
            .WithSummary("deletes operation by id")
            .WithDescription("deletes operation by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Operations.Delete")
            .MapToApiVersion(1);
    }
}
