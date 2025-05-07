using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class PlaneEngineConfiguration : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; } = string.Empty;

    private PlaneEngineConfiguration() { }

    private PlaneEngineConfiguration(Guid id, string name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new PlaneEngineConfigurationCreated { PlaneEngineConfiguration = this });
    }

    public static PlaneEngineConfiguration Create(string name)
    {
        return new PlaneEngineConfiguration(Guid.NewGuid(), name);
    }

    public PlaneEngineConfiguration Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new PlaneEngineConfigurationUpdated { PlaneEngineConfiguration = this });
        }

        return this;
    }
}
