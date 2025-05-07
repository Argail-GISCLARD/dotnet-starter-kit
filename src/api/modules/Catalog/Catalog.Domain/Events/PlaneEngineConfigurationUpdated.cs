using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneEngineConfigurationUpdated : DomainEvent
{
    public PlaneEngineConfiguration? PlaneEngineConfiguration { get; set; }
}
