using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneManufacturerCreated : DomainEvent
{
    public PlaneManufacturer? PlaneManufacturer { get; set; }
}
