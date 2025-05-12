using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.PlaneModels.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Search.v1;
public sealed class SearchPlaneModelsHandler(
    [FromKeyedServices("catalog:planemodels")] IReadRepository<PlaneModel> repository)
    : IRequestHandler<SearchPlaneModelsCommand, PagedList<PlaneModelResponse>>
{
    public async Task<PagedList<PlaneModelResponse>> Handle(SearchPlaneModelsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchPlaneModelSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<PlaneModelResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
