using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
public sealed class GetJacXsonHandler(
    [FromKeyedServices("catalog:jacxsons")] IReadRepository<JacXson> repository,
    ICacheService cache)
    : IRequestHandler<GetJacXsonRequest, JacXsonResponse>
{
    public async Task<JacXsonResponse> Handle(GetJacXsonRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"jacxson:{request.Id}",
            async () =>
            {
                var jacXsonItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (jacXsonItem == null) throw new JacXsonNotFoundException(request.Id);
                return new JacXsonResponse(jacXsonItem.Id, jacXsonItem.SerialNumber, jacXsonItem.Status, jacXsonItem.W0, jacXsonItem.L, jacXsonItem.Salt);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
