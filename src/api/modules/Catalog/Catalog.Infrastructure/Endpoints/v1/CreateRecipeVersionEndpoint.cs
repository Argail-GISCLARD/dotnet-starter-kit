using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateRecipeVersionEndpoint
{
    internal static RouteHandlerBuilder MapRecipeVersionCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateRecipeVersionCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateRecipeVersionEndpoint))
            .WithSummary("creates a recipeversion")
            .WithDescription("creates a recipeversion")
            .Produces<CreateRecipeVersionResponse>()
            .RequirePermission("Permissions.RecipeVersions.Create")
            .MapToApiVersion(1);
    }
}
