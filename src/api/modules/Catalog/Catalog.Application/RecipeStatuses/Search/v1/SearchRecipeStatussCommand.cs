using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Search.v1;

public class SearchRecipeStatussCommand : PaginationFilter, IRequest<PagedList<RecipeStatusResponse>>
{
    public int? Status { get; set; }
}
