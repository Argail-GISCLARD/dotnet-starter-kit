using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneEngineUpdated : DomainEvent
{
    public PlaneEngine? PlaneEngine { get; set; }
}
