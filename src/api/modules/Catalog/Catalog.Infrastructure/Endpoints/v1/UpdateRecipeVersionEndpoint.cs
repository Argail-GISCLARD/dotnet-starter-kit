using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateRecipeVersionEndpoint
{
    internal static RouteHandlerBuilder MapRecipeVersionUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateRecipeVersionCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateRecipeVersionEndpoint))
            .WithSummary("update a recipeversion")
            .WithDescription("update a recipeversion")
            .Produces<UpdateRecipeVersionResponse>()
            .RequirePermission("Permissions.RecipeVersions.Update")
            .MapToApiVersion(1);
    }
}
