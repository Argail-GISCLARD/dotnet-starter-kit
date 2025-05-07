using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneEngineCreated : DomainEvent
{
    public PlaneEngine? PlaneEngine { get; set; }
}
