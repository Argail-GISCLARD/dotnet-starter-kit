using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeContentNotFoundException : NotFoundException
{
    public RecipeContentNotFoundException(Guid id)
        : base($"recipe content with id {id} not found")
    {
    }
}
