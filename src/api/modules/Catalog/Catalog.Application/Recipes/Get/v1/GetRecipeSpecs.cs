using Ardalis.Specification;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;

public class GetRecipeSpecs : Specification<Recipe, RecipeResponse>
{
    public GetRecipeSpecs(Guid id)
    {
        Query
            .Where(p => p.Id == id);
    }
}
