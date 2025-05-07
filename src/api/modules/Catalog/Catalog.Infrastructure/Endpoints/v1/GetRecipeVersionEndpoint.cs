using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class GetRecipeVersionEndpoint
{
    internal static RouteHandlerBuilder MapGetRecipeVersionEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetRecipeVersionRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetRecipeVersionEndpoint))
            .WithSummary("gets recipeversion by id")
            .WithDescription("gets recipeversion by id")
            .Produces<RecipeVersionResponse>()
            .RequirePermission("Permissions.RecipeVersions.View")
            .MapToApiVersion(1);
    }
}
