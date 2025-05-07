using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeChangelogUpdated : DomainEvent
{
    public RecipeChangelog? RecipeChangelog { get; set; }
}
