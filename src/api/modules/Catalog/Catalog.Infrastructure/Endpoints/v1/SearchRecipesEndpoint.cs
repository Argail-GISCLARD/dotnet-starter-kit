using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;

public static class SearchRecipesEndpoint
{
    internal static RouteHandlerBuilder MapGetRecipeListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] SearchRecipesCommand command) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchRecipesEndpoint))
            .WithSummary("Gets a list of recipes")
            .WithDescription("Gets a list of recipes with pagination and filtering support")
            .Produces<PagedList<RecipeResponse>>()
            .RequirePermission("Permissions.Recipes.View")
            .MapToApiVersion(1);
    }
}
