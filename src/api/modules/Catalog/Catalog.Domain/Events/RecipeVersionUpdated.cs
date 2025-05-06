using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeVersionUpdated : DomainEvent
{
    public RecipeVersion? RecipeVersion { get; set; }
}
