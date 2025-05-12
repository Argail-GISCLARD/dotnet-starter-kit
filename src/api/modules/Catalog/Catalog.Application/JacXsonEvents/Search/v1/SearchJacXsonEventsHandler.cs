using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Search.v1;
public sealed class SearchJacXsonEventsHandler(
    [FromKeyedServices("catalog:jacxsonevents")] IReadRepository<JacXsonEvent> repository)
    : IRequestHandler<SearchJacXsonEventsCommand, PagedList<JacXsonEventResponse>>
{
    public async Task<PagedList<JacXsonEventResponse>> Handle(SearchJacXsonEventsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchJacXsonEventSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<JacXsonEventResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
