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
            .Where(r => r.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
