using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class JacXsonNotFoundException : NotFoundException
{
    public JacXsonNotFoundException(Guid id)
        : base($"jacxson with id {id} not found")
    {
    }
}
