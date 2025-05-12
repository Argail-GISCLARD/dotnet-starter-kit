using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeTemplateContent : AuditableEntity, IAggregateRoot
{
    public string? Content { get; private set; } = string.Empty;

    private RecipeTemplateContent() { }

    private RecipeTemplateContent(Guid id, string? content)
    {
        Id = id;
        Content = content;
        QueueDomainEvent(new RecipeTemplateContentCreated { RecipeTemplateContent = this });
    }

    public static RecipeTemplateContent Create(string? content)
    {
        return new RecipeTemplateContent(Guid.NewGuid(), content);
    }

    public RecipeTemplateContent Update(string? content)
    {
        bool isUpdated = false;

        if (!string.Equals(Content, content, StringComparison.OrdinalIgnoreCase))
        {
            Content = content;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeTemplateContentUpdated { RecipeTemplateContent = this });
        }

        return this;
    }
}


