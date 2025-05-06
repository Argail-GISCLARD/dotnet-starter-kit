using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateRecipeEndpoint
{
    internal static RouteHandlerBuilder MapRecipeUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateRecipeCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateRecipeEndpoint))
            .WithSummary("update a recipe")
            .WithDescription("update a recipe")
            .Produces<UpdateRecipeResponse>()
            .RequirePermission("Permissions.Recipes.Update")
            .MapToApiVersion(1);
    }
}
