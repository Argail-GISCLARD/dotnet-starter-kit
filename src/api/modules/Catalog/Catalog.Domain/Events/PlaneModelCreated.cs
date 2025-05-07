using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneModelCreated : DomainEvent
{
    public PlaneModel? PlaneModel { get; set; }
}
