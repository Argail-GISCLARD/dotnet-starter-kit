using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Search.v1;
public sealed class SearchOperationsHandler(
    [FromKeyedServices("catalog:operations")] IReadRepository<Operation> repository)
    : IRequestHandler<SearchOperationsCommand, PagedList<OperationResponse>>
{
    public async Task<PagedList<OperationResponse>> Handle(SearchOperationsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchOperationSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<OperationResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}

