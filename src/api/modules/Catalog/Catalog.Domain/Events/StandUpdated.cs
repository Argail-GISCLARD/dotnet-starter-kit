using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record StandUpdated : DomainEvent
{
    public Stand? Stand { get; set; }
}
