using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Search.v1;

public class SearchRecipeVersionsCommand : PaginationFilter, IRequest<PagedList<RecipeVersionResponse>>
{
    public int VersionNumber { get; set; }
}
