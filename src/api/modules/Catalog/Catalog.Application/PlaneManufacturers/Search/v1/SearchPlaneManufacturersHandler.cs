using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Search.v1;
public sealed class SearchPlaneManufacturersHandler(
    [FromKeyedServices("catalog:planemanufacturers")] IReadRepository<PlaneManufacturer> repository)
    : IRequestHandler<SearchPlaneManufacturersCommand, PagedList<PlaneManufacturerResponse>>
{
    public async Task<PagedList<PlaneManufacturerResponse>> Handle(SearchPlaneManufacturersCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchPlaneManufacturerSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<PlaneManufacturerResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
