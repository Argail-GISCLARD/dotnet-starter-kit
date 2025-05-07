using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeStatusCreated : DomainEvent
{
    public RecipeStatus? RecipeStatus { get; set; }
}
