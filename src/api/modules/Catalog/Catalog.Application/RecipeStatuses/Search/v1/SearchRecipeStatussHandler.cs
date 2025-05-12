using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Search.v1;
public sealed class SearchRecipeStatussHandler(
    [FromKeyedServices("catalog:recipestatuses")] IReadRepository<RecipeStatus> repository)
    : IRequestHandler<SearchRecipeStatussCommand, PagedList<RecipeStatusResponse>>
{
    public async Task<PagedList<RecipeStatusResponse>> Handle(SearchRecipeStatussCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchRecipeStatusSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<RecipeStatusResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
