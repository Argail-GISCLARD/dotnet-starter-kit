using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Search.v1;
public sealed class SearchRecipeVersionsHandler(
    [FromKeyedServices("catalog:recipeversions")] IReadRepository<RecipeVersion> repository)
    : IRequestHandler<SearchRecipeVersionsCommand, PagedList<RecipeVersionResponse>>
{
    public async Task<PagedList<RecipeVersionResponse>> Handle(SearchRecipeVersionsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchRecipeVersionSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<RecipeVersionResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
