using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Get.v1;
public sealed class GetPlaneManufacturerHandler(
    [FromKeyedServices("catalog:planemanufacturers")] IReadRepository<PlaneManufacturer> repository,
    ICacheService cache)
    : IRequestHandler<GetPlaneManufacturerRequest, PlaneManufacturerResponse>
{
    public async Task<PlaneManufacturerResponse> Handle(GetPlaneManufacturerRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"planemanufacturer:{request.Id}",
            async () =>
            {
                var planeManufacturerItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (planeManufacturerItem == null) throw new PlaneManufacturerNotFoundException(request.Id);
                return new PlaneManufacturerResponse(planeManufacturerItem.Id, planeManufacturerItem.Name);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
