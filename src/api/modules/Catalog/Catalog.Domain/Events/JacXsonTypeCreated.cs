using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonTypeCreated : DomainEvent
{
    public JacXsonType? JacXsonType { get; set; }
}
