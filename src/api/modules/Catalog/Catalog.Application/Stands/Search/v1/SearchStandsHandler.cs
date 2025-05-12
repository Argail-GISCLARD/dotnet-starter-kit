using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Stands.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Search.v1;
public sealed class SearchStandsHandler(
    [FromKeyedServices("catalog:stands")] IReadRepository<Stand> repository)
    : IRequestHandler<SearchStandsCommand, PagedList<StandResponse>>
{
    public async Task<PagedList<StandResponse>> Handle(SearchStandsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchStandSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<StandResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
