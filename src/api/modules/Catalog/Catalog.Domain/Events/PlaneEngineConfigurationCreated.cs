using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneEngineConfigurationCreated : DomainEvent
{
    public PlaneEngineConfiguration? PlaneEngineConfiguration { get; set; }
}
