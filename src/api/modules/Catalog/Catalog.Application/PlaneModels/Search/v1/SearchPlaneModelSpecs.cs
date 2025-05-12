using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.PlaneModels.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Search.v1;
public class SearchPlaneModelSpecs : EntitiesByPaginationFilterSpec<PlaneModel, PlaneModelResponse>
{
    public SearchPlaneModelSpecs(SearchPlaneModelsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(b => b.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
