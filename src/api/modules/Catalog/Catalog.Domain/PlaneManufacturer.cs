using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class PlaneManufacturer : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;

    private PlaneManufacturer() { }

    private PlaneManufacturer(Guid id, string name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new PlaneManufacturerCreated { PlaneManufacturer = this });
    }

    public static PlaneManufacturer Create(string name)
    {
        return new PlaneManufacturer(Guid.NewGuid(), name);
    }

    public PlaneManufacturer Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new PlaneManufacturerUpdated { PlaneManufacturer = this });
        }

        return this;
    }
}
