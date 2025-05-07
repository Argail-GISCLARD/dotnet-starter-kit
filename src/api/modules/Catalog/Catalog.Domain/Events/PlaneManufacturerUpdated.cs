using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneManufacturerUpdated : DomainEvent
{
    public PlaneManufacturer? PlaneManufacturer { get; set; }
}
