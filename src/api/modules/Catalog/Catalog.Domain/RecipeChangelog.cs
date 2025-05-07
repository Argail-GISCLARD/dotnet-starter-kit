using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeChangelog : AuditableEntity, IAggregateRoot
{
    public string? Content { get; private set; } = string.Empty;
    public string? Summary { get; private set; } = string.Empty;

    public virtual RecipeVersion RecipeVersion { get; private set; } = default!;

    private RecipeChangelog() { }

    private RecipeChangelog(Guid id, string? content, string? summary)
    {
        Id = id;
        Content = content;
        Summary = summary;
        QueueDomainEvent(new RecipeChangelogCreated { RecipeChangelog = this });
    }

    public static RecipeChangelog Create(string? content, string? summary)
    {
        return new RecipeChangelog(Guid.NewGuid(), content, summary);
    }

    public RecipeChangelog Update(string? content, string? summary)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(content) && !string.Equals(Content, content, StringComparison.OrdinalIgnoreCase))
        {
            Content = content;
            isUpdated = true;
        }

        if (!string.IsNullOrWhiteSpace(summary) && !string.Equals(Summary, summary, StringComparison.OrdinalIgnoreCase))
        {
            Summary = summary;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeChangelogUpdated { RecipeChangelog = this });
        }

        return this;
    }
}
