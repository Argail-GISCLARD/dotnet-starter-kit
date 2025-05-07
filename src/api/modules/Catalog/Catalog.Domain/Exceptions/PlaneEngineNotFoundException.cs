using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class PlaneEngineNotFoundException : NotFoundException
{
    public PlaneEngineNotFoundException(Guid id)
        : base($"plane engine with id {id} not found")
    {
    }
}
