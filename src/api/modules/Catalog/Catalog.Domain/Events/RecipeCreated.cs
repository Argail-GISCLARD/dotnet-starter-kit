using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeCreated : DomainEvent
{
    public Recipe? Recipe { get; set; }
}
