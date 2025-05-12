using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Search.v1;
public class SearchJacXsonEventSpecs : EntitiesByPaginationFilterSpec<JacXsonEvent, JacXsonEventResponse>
{
    public SearchJacXsonEventSpecs(SearchJacXsonEventsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.JacXsonSerialNumber, !command.HasOrderBy())
            .Where(b => b.JacXsonSerialNumber.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
