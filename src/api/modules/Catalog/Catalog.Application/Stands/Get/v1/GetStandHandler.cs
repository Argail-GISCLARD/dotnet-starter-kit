using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Get.v1;
public sealed class GetStandHandler(
    [FromKeyedServices("catalog:stands")] IReadRepository<Stand> repository,
    ICacheService cache)
    : IRequestHandler<GetStandRequest, StandResponse>
{
    public async Task<StandResponse> Handle(GetStandRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"Stand:{request.Id}",
            async () =>
            {
                var standItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (standItem == null) throw new StandNotFoundException(request.Id);
                return new StandResponse(standItem.Id, standItem.Name);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
