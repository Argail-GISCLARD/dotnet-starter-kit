using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonEventUpdated : DomainEvent
{
    public JacXsonEvent? JacXsonEvent { get; set; }
}
