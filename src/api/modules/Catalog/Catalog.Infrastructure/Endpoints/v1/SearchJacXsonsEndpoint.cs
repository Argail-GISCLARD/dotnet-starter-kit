using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;

public static class SearchJacXsonsEndpoint
{
    internal static RouteHandlerBuilder MapGetJacXsonListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] SearchJacXsonsCommand command) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchJacXsonsEndpoint))
            .WithSummary("Gets a list of jacxsons")
            .WithDescription("Gets a list of jacxsons with pagination and filtering support")
            .Produces<PagedList<JacXsonResponse>>()
            .RequirePermission("Permissions.JacXsons.View")
            .MapToApiVersion(1);
    }
}
