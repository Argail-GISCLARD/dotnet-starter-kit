using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeContentUpdated : DomainEvent
{
    public RecipeContent? RecipeContent { get; set; }
}
