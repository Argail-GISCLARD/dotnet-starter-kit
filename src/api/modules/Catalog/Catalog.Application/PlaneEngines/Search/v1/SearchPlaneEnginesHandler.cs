using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Search.v1;
public sealed class SearchPlaneEnginesHandler(
    [FromKeyedServices("catalog:planeengines")] IReadRepository<PlaneEngine> repository)
    : IRequestHandler<SearchPlaneEnginesCommand, PagedList<PlaneEngineResponse>>
{
    public async Task<PagedList<PlaneEngineResponse>> Handle(SearchPlaneEnginesCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchPlaneEngineSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<PlaneEngineResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
