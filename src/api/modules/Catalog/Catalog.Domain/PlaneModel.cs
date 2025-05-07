using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class PlaneModel : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;

    private PlaneModel() { }

    private PlaneModel(Guid id, string name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new PlaneModelCreated { PlaneModel = this });
    }

    public static PlaneModel Create(string name)
    {
        return new PlaneModel(Guid.NewGuid(), name);
    }

    public PlaneModel Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new PlaneModelUpdated { PlaneModel = this });
        }

        return this;
    }
}
