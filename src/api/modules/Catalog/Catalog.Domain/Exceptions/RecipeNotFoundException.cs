using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeNotFoundException : NotFoundException
{
    public RecipeNotFoundException(Guid id)
        : base($"recipe with id {id} not found")
    {
    }
}
