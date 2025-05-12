using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Search.v1;

public class SearchJacXsonEventsCommand : PaginationFilter, IRequest<PagedList<JacXsonEventResponse>>
{
    public string? EventName { get; set; }
}
