using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Search.v1;

public class SearchRecipeTemplatesCommand : PaginationFilter, IRequest<PagedList<RecipeTemplateResponse>>
{
    public int? VersionNumber { get; set; }
    public string? Publisher { get; set; }
}
