using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.Operations.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;

public static class SearchOperationsEndpoint
{
    internal static RouteHandlerBuilder MapGetOperationListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] SearchOperationsCommand command) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchOperationsEndpoint))
            .WithSummary("Gets a list of operations")
            .WithDescription("Gets a list of operations with pagination and filtering support")
            .Produces<PagedList<OperationResponse>>()
            .RequirePermission("Permissions.Operations.View")
            .MapToApiVersion(1);
    }
}

