using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Search.v1;
public sealed class SearchRecipeTemplatesHandler(
    [FromKeyedServices("catalog:recipetemplates")] IReadRepository<RecipeTemplate> repository)
    : IRequestHandler<SearchRecipeTemplatesCommand, PagedList<RecipeTemplateResponse>>
{
    public async Task<PagedList<RecipeTemplateResponse>> Handle(SearchRecipeTemplatesCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchRecipeTemplateSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<RecipeTemplateResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
