using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Recipe : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; } = string.Empty;
    public int Version { get; set; } = 0; 
    public string? Content { get; set; } = string.Empty;
    public string? Changelog { get; set; } = string.Empty;

    private Recipe() { }

    private Recipe(Guid id, string? name, int version, string? content, string? changelog)
    {
        Id = id;
        Name = name;
        Version = version;
        Content = content;
        Changelog = changelog;
        QueueDomainEvent(new RecipeCreated { Recipe = this });
    }

    public static Recipe Create(string? name, int version, string? content, string? changelog)
    {
        return new Recipe(Guid.NewGuid(), name, version, content, changelog);
    }

    public Recipe Update(string? name, string? content, string? changelog)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (!string.Equals(Content, content, StringComparison.OrdinalIgnoreCase))
        {
            Content = content;
            isUpdated = true;
        }

        if (!string.Equals(Changelog, changelog, StringComparison.OrdinalIgnoreCase))
        {
            Changelog = changelog;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeUpdated { Recipe = this });
        }

        return this;
    }
}
