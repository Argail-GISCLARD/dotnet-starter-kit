using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeVersionCreated : DomainEvent
{
    public RecipeVersion? RecipeVersion { get; set; }
}
