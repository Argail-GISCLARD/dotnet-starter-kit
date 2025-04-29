using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Search.v1;
public sealed class SearchRecipesHandler(
    [FromKeyedServices("catalog:recipes")] IReadRepository<Recipe> repository)
    : IRequestHandler<SearchRecipesCommand, PagedList<RecipeResponse>>
{
    public async Task<PagedList<RecipeResponse>> Handle(SearchRecipesCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchRecipeSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<RecipeResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}

