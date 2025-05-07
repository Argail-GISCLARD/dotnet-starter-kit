using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record StandCreated : DomainEvent
{
    public Stand? Stand { get; set; }
}
