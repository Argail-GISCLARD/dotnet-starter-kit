using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Recipe : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; } = string.Empty;

    private Recipe() { }

    private Recipe(Guid id, string? name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new RecipeCreated { Recipe = this });
    }

    public static Recipe Create(string? name)
    {
        return new Recipe(Guid.NewGuid(), name);
    }

    public Recipe Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeUpdated { Recipe = this });
        }

        return this;
    }
}
