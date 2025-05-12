using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Get.v1;
public sealed class GetJacXsonEventHandler(
    [FromKeyedServices("catalog:jacxsonevents")] IReadRepository<JacXsonEvent> repository,
    ICacheService cache)
    : IRequestHandler<GetJacXsonEventRequest, JacXsonEventResponse>
{
    public async Task<JacXsonEventResponse> Handle(GetJacXsonEventRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"jacxsonevent:{request.Id}",
            async () =>
            {
                var JacXsonEventItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (JacXsonEventItem == null) throw new JacXsonEventNotFoundException(request.Id);
                return new JacXsonEventResponse(JacXsonEventItem.Id, JacXsonEventItem.JacXsonSerialNumber, JacXsonEventItem.OccuredAt, JacXsonEventItem.Source, JacXsonEventItem.EventName, JacXsonEventItem.Details);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
