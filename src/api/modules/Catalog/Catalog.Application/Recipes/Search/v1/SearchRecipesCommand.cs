using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Search.v1;

public class SearchRecipesCommand : PaginationFilter, IRequest<PagedList<RecipeResponse>>
{
    public string? Name { get; set; }
}
