using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record JacXsonRecipeVersionUpdated : DomainEvent
{
    public JacXsonRecipeVersion? JacXsonRecipeVersion { get; set; }
}
