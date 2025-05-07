using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Search.v1;
public class SearchOperationSpecs : EntitiesByPaginationFilterSpec<Operation, OperationResponse>
{
    public SearchOperationSpecs(SearchOperationsCommand command)
        : base(command) =>
        Query
            .Include(o => o.RecipeOperations)
            .OrderBy(c => c.Name, !command.HasOrderBy());
}
