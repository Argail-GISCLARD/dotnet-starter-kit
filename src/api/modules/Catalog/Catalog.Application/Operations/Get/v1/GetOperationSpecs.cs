using Ardalis.Specification;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;

public class GetOperationSpecs : Specification<Operation, OperationResponse>
{
    public GetOperationSpecs(Guid id)
    {
        Query
            .Where(p => p.Id == id)
            .Include(p => p.RecipeOperations);
    }
}
