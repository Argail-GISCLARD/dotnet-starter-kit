using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Get.v1;
public sealed class GetJacXsonTypeHandler(
    [FromKeyedServices("catalog:jacxsontypes")] IReadRepository<JacXsonType> repository,
    ICacheService cache)
    : IRequestHandler<GetJacXsonTypeRequest, JacXsonTypeResponse>
{
    public async Task<JacXsonTypeResponse> Handle(GetJacXsonTypeRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"jacxsontype:{request.Id}",
            async () =>
            {
                var JacXsonTypeItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (JacXsonTypeItem == null) throw new JacXsonTypeNotFoundException(request.Id);
                return new JacXsonTypeResponse(JacXsonTypeItem.Id, JacXsonTypeItem.Name);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
