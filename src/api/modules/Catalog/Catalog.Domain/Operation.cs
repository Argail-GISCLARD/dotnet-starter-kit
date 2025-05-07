using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Operation : AuditableEntity, IAggregateRoot
{
    public string? Name { get; set; } = string.Empty;

    public virtual Collection<RecipeVersion> RecipeVersions { get; private set; } = [];

    private Operation() { }

    private Operation(Guid id, string? name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new OperationCreated { Operation = this });
    }

    public static Operation Create(string? name)
    {
        return new Operation(Guid.NewGuid(), name);
    }

    public Operation Update(string? name, Collection<RecipeVersion>? recipeVersions)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (recipeVersions != null && recipeVersions.Count > 0)
        {
            RecipeVersions = recipeVersions;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new OperationCreated { Operation = this });
        }

        return this;
    }
}
