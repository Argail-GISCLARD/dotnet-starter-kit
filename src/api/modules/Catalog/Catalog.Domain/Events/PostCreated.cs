using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PostCreated : DomainEvent
{
    public Post? Post { get; set; }
}
