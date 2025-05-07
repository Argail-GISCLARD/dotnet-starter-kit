using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonEventCreated : DomainEvent
{
    public JacXsonEvent? JacXsonEvent { get; set; }
}
