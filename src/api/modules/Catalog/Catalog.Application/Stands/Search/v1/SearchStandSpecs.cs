using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.Stands.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Search.v1;
public class SearchStandSpecs : EntitiesByPaginationFilterSpec<Stand, StandResponse>
{
    public SearchStandSpecs(SearchStandsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(b => b.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
