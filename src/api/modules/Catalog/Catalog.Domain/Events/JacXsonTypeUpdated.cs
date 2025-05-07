using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonTypeUpdated : DomainEvent
{
    public JacXsonType? JacXsonType { get; set; }
}
