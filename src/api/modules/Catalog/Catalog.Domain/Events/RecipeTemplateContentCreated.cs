using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record RecipeTemplateContentCreated : DomainEvent
{
    public RecipeTemplateContent? RecipeTemplateContent { get; set; }
}
