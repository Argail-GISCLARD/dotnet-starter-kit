using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateRecipeEndpoint
{
    internal static RouteHandlerBuilder MapRecipeCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateRecipeCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateRecipeEndpoint))
            .WithSummary("creates a recipe")
            .WithDescription("creates a recipe")
            .Produces<CreateRecipeResponse>()
            .RequirePermission("Permissions.Recipes.Create")
            .MapToApiVersion(1);
    }
}
