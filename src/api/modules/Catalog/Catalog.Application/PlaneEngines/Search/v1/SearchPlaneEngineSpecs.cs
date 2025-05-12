using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Search.v1;
public class SearchPlaneEngineSpecs : EntitiesByPaginationFilterSpec<PlaneEngine, PlaneEngineResponse>
{
    public SearchPlaneEngineSpecs(SearchPlaneEnginesCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(b => b.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
