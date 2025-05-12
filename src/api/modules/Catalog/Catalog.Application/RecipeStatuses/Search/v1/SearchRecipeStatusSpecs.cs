using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Search.v1;
public class SearchRecipeStatusSpecs : EntitiesByPaginationFilterSpec<RecipeStatus, RecipeStatusResponse>
{
    public SearchRecipeStatusSpecs(SearchRecipeStatussCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Status, !command.HasOrderBy())
            .Where(b => b.Status == command.Status!.Value, command.Status.HasValue);
}
