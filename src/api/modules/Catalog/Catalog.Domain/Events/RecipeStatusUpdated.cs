using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeStatusUpdated : DomainEvent
{
    public RecipeStatus? RecipeStatus { get; set; }
}
