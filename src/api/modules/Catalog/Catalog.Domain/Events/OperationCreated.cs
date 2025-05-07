using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record OperationCreated : DomainEvent
{
    public Operation? Operation { get; set; }
}
