using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeTemplateCreated : DomainEvent
{
    public RecipeTemplate? RecipeTemplate { get; set; }
}
