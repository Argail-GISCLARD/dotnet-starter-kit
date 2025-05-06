using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeVersionNotFoundException : NotFoundException
{
    public RecipeVersionNotFoundException(Guid id)
        : base($"recipeVersion with id {id} not found")
    {
    }
}
