using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Get.v1;
public sealed class GetPlaneEngineHandler(
    [FromKeyedServices("catalog:planeengines")] IReadRepository<PlaneEngine> repository,
    ICacheService cache)
    : IRequestHandler<GetPlaneEngineRequest, PlaneEngineResponse>
{
    public async Task<PlaneEngineResponse> Handle(GetPlaneEngineRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"planeengine:{request.Id}",
            async () =>
            {
                var planeEngineItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (planeEngineItem == null) throw new PlaneEngineNotFoundException(request.Id);
                return new PlaneEngineResponse(planeEngineItem.Id, planeEngineItem.Name);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
