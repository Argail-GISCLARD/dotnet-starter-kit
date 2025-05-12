using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeTemplateNotFoundException : NotFoundException
{
    public RecipeTemplateNotFoundException(Guid id)
        : base($"recipe template with id {id} not found")
    {
    }
}
