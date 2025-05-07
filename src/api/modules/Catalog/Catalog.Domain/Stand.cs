using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Stand : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;

    private Stand() { }

    private Stand(Guid id, string name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new StandCreated { Stand = this });
    }

    public static Stand Create(string name)
    {
        return new Stand(Guid.NewGuid(), name);
    }

    public Stand Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new StandUpdated { Stand = this });
        }

        return this;
    }
}
