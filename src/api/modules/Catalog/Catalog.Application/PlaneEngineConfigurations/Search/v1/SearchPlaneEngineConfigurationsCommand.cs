using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Search.v1;

public class SearchPlaneEngineConfigurationsCommand : PaginationFilter, IRequest<PagedList<PlaneEngineConfigurationResponse>>
{}
