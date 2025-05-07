using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;

public static class SearchRecipeVersionsEndpoint
{
    internal static RouteHandlerBuilder MapGetRecipeVersionListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] SearchRecipeVersionsCommand command) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchRecipeVersionsEndpoint))
            .WithSummary("Gets a list of recipeversions")
            .WithDescription("Gets a list of recipeversions with pagination and filtering support")
            .Produces<PagedList<RecipeVersionResponse>>()
            .RequirePermission("Permissions.RecipeVersions.View")
            .MapToApiVersion(1);
    }
}
