using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class RecipeTemplateContentNotFoundException : NotFoundException
{
    public RecipeTemplateContentNotFoundException(Guid id)
        : base($"recipe template content with id {id} not found")
    {
    }
}
