using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class PlaneModelNotFoundException : NotFoundException
{
    public PlaneModelNotFoundException(Guid id)
        : base($"plane model with id {id} not found")
    {
    }
}
