using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Search.v1;
public class SearchPlaneManufacturerSpecs : EntitiesByPaginationFilterSpec<PlaneManufacturer, PlaneManufacturerResponse>
{
    public SearchPlaneManufacturerSpecs(SearchPlaneManufacturersCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(b => b.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword));
}
