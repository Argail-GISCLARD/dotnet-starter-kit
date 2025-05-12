using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Get.v1;
public sealed class GetPlaneEngineConfigurationHandler(
    [FromKeyedServices("catalog:planeengineconfigurations")] IReadRepository<PlaneEngineConfiguration> repository,
    ICacheService cache)
    : IRequestHandler<GetPlaneEngineConfigurationRequest, PlaneEngineConfigurationResponse>
{
    public async Task<PlaneEngineConfigurationResponse> Handle(GetPlaneEngineConfigurationRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"planeengineconfiguration:{request.Id}",
            async () =>
            {
                var planeEngineConfigurationItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (planeEngineConfigurationItem == null) throw new PlaneEngineConfigurationNotFoundException(request.Id);
                return new PlaneEngineConfigurationResponse(planeEngineConfigurationItem.Id, planeEngineConfigurationItem.Name);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
