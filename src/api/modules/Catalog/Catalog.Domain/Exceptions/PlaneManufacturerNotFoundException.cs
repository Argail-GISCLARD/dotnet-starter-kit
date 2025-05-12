using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class PlaneManufacturerNotFoundException : NotFoundException
{
    public PlaneManufacturerNotFoundException(Guid id)
        : base($"plane manufacturer with id {id} not found")
    {
    }
}
