using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Get.v1;
public sealed class GetPlaneModelHandler(
    [FromKeyedServices("catalog:planemodels")] IReadRepository<PlaneModel> repository,
    ICacheService cache)
    : IRequestHandler<GetPlaneModelRequest, PlaneModelResponse>
{
    public async Task<PlaneModelResponse> Handle(GetPlaneModelRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"planemodel:{request.Id}",
            async () =>
            {
                var planeModelItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (planeModelItem == null) throw new PlaneModelNotFoundException(request.Id);
                return new PlaneModelResponse(planeModelItem.Id, planeModelItem.Name);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
