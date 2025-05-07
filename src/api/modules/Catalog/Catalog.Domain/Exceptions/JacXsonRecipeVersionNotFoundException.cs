using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class JacXsonRecipeVersionNotFoundException : NotFoundException
{
    public JacXsonRecipeVersionNotFoundException(Guid id)
        : base($"jacxson recipe version with id {id} not found")
    {
    }
}
