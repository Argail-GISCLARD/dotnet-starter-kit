using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Search.v1;
public sealed class SearchPlaneEngineConfigurationsHandler(
    [FromKeyedServices("catalog:planeengineconfigurations")] IReadRepository<PlaneEngineConfiguration> repository)
    : IRequestHandler<SearchPlaneEngineConfigurationsCommand, PagedList<PlaneEngineConfigurationResponse>>
{
    public async Task<PagedList<PlaneEngineConfigurationResponse>> Handle(SearchPlaneEngineConfigurationsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchPlaneEngineConfigurationSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<PlaneEngineConfigurationResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
