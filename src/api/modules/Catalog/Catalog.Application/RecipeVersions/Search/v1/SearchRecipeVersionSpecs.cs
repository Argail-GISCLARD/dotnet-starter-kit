using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Search.v1;
public class SearchRecipeVersionSpecs : EntitiesByPaginationFilterSpec<RecipeVersion, RecipeVersionResponse>
{
    public SearchRecipeVersionSpecs(SearchRecipeVersionsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.VersionNumber, !command.HasOrderBy())
            .Where(b => b.VersionNumber.Equals(command.VersionNumber));
}
