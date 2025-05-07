using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Operations.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateOperationEndpoint
{
    internal static RouteHandlerBuilder MapOperationUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateOperationCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateOperationEndpoint))
            .WithSummary("update a operation")
            .WithDescription("update a operation")
            .Produces<UpdateOperationResponse>()
            .RequirePermission("Permissions.Operations.Update")
            .MapToApiVersion(1);
    }
}
