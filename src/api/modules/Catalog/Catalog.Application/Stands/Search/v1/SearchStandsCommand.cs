using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Stands.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Search.v1;

public class SearchStandsCommand : PaginationFilter, IRequest<PagedList<StandResponse>>
{
    public string? Name { get; set; }
}
