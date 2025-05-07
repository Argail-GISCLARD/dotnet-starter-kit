using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class JacXsonTypeNotFoundException : NotFoundException
{
    public JacXsonTypeNotFoundException(Guid id)
        : base($"jacxson type with id {id} not found")
    {
    }
}
