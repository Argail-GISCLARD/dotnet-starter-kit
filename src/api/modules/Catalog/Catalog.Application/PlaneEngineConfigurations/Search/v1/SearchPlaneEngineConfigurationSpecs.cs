using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Search.v1;
public class SearchPlaneEngineConfigurationSpecs : EntitiesByPaginationFilterSpec<PlaneEngineConfiguration, PlaneEngineConfigurationResponse>
{
    public SearchPlaneEngineConfigurationSpecs(SearchPlaneEngineConfigurationsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(b => b.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
