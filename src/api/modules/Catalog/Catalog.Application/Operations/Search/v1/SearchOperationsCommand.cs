using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Search.v1;

public class SearchOperationsCommand : PaginationFilter, IRequest<PagedList<OperationResponse>>
{
    public string? Name { get; set; }
}
