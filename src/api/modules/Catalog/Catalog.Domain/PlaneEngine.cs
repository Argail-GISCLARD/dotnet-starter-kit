using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class PlaneEngine : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;

    private PlaneEngine() { }

    private PlaneEngine(Guid id, string name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new PlaneEngineCreated { PlaneEngine = this });
    }

    public static PlaneEngine Create(string name)
    {
        return new PlaneEngine(Guid.NewGuid(), name);
    }

    public PlaneEngine Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new PlaneEngineUpdated { PlaneEngine = this });
        }

        return this;
    }
}
