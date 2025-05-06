using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Search.v1;
public sealed class SearchJacXsonsHandler(
    [FromKeyedServices("catalog:jacxsons")] IReadRepository<JacXson> repository)
    : IRequestHandler<SearchJacXsonsCommand, PagedList<JacXsonResponse>>
{
    public async Task<PagedList<JacXsonResponse>> Handle(SearchJacXsonsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchJacXsonSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<JacXsonResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
