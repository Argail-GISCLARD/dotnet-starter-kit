using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Search.v1;

public class SearchPlaneEnginesCommand : PaginationFilter, IRequest<PagedList<PlaneEngineResponse>>
{}
