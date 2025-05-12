using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeTemplateContentUpdated : DomainEvent
{
    public RecipeTemplateContent? RecipeTemplateContent { get; set; }
}
