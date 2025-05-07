using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record PlaneModelUpdated : DomainEvent
{
    public PlaneModel? PlaneModel { get; set; }
}
