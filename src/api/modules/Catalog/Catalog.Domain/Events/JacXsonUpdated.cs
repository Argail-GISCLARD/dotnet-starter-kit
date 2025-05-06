using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonUpdated : DomainEvent
{
    public JacXson? JacXson{ get; set; }
}
