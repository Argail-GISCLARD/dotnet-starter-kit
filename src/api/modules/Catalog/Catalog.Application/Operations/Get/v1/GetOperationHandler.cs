using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
public sealed class GetOperationHandler(
    [FromKeyedServices("catalog:operations")] IReadRepository<Operation> repository,
    ICacheService cache)
    : IRequestHandler<GetOperationRequest, OperationResponse>
{
    public async Task<OperationResponse> Handle(GetOperationRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"operation:{request.Id}",
            async () =>
            {
                var spec = new GetOperationSpecs(request.Id);
                var operationItem = await repository.FirstOrDefaultAsync(spec, cancellationToken);
                if (operationItem == null) throw new OperationNotFoundException(request.Id);
                return operationItem;
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
