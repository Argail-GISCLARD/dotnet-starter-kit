using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.PlaneModels.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Search.v1;

public class SearchPlaneModelsCommand : PaginationFilter, IRequest<PagedList<PlaneModelResponse>>
{
}
