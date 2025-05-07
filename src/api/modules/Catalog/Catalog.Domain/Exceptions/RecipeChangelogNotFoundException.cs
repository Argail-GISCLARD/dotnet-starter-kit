using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeChangelogNotFoundException : NotFoundException
{
    public RecipeChangelogNotFoundException(Guid id)
        : base($"recipe changelog with id {id} not found")
    {
    }
}
