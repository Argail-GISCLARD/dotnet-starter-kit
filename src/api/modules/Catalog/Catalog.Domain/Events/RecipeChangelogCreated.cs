using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeChangelogCreated : DomainEvent
{
    public RecipeChangelog? RecipeChangelog { get; set; }
}
