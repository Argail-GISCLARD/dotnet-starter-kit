using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeStatusNotFoundException : NotFoundException
{
    public RecipeStatusNotFoundException(Guid id)
        : base($"recipe status with id {id} not found")
    {
    }
}
