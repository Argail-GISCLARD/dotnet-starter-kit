using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Search.v1;
public class SearchRecipeSpecs : EntitiesByPaginationFilterSpec<Recipe, RecipeResponse>
{
    public SearchRecipeSpecs(SearchRecipesCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(p => p.Version >= command.MinimumVersion!.Value, command.MinimumVersion.HasValue)
            .Where(p => p.Version <= command.MaximumVersion!.Value, command.MaximumVersion.HasValue);
}
