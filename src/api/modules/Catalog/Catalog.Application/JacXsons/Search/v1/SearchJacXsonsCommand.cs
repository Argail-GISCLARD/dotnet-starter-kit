using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Search.v1;

public class SearchJacXsonsCommand : PaginationFilter, IRequest<PagedList<JacXsonResponse>>
{
    public string? SerialNumber { get; set; }
}
