using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class JacXsonEventNotFoundException : NotFoundException
{
    public JacXsonEventNotFoundException(Guid id)
        : base($"jacxson event with id {id} not found")
    {
    }
}
