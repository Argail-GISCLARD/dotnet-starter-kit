using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeContent : AuditableEntity, IAggregateRoot
{
    public string? Content { get; private set; } = string.Empty;
    public string? Checksum { get; private set; } = string.Empty;

    public virtual RecipeVersion RecipeVersion { get; private set; } = default!;

    private RecipeContent() { }

    private RecipeContent(Guid id, string? content, string? checksum)
    {
        Id = id;
        Content = content;
        Checksum = checksum;
        QueueDomainEvent(new RecipeContentCreated { RecipeContent = this });
    }

    public static RecipeContent Create(string? content, string? checksum)
    {
        return new RecipeContent(Guid.NewGuid(), content, checksum);
    }

    public RecipeContent Update(string? content, string? checksum)
    {
        bool isUpdated = false;

        if (content != null && content != Content)
        {
            Content = content;
            isUpdated = true;
        }

        if (checksum != null && checksum != Checksum)
        {
            Checksum = checksum;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeContentUpdated { RecipeContent = this });
        }

        return this;
    }
}
