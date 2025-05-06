using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonCreated : DomainEvent
{
    public JacXson? JacXson { get; set; }
}
