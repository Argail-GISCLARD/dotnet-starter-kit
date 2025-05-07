using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class DeleteRecipeVersionEndpoint
{
    internal static RouteHandlerBuilder MapRecipeVersionDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteRecipeVersionCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteRecipeVersionEndpoint))
            .WithSummary("deletes recipeversion by id")
            .WithDescription("deletes recipeversion by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.RecipeVersions.Delete")
            .MapToApiVersion(1);
    }
}
