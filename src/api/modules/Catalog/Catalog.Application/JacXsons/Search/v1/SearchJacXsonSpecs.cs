using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Search.v1;
public class SearchJacXsonSpecs : EntitiesByPaginationFilterSpec<JacXson, JacXsonResponse>
{
    public SearchJacXsonSpecs(SearchJacXsonsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.SerialNumber, !command.HasOrderBy())
            .Where(b => b.SerialNumber.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
