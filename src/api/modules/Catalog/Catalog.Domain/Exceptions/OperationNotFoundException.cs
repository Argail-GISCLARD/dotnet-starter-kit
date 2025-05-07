using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class OperationNotFoundException : NotFoundException
{
    public OperationNotFoundException(Guid id)
        : base($"operation with id {id} not found")
    {
    }
}
