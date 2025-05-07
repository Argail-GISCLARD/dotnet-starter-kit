using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;

public class JacXsonType : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;

    private JacXsonType() { }

    private JacXsonType(Guid id, string name)
    {
        Id = id;
        Name = name;
        QueueDomainEvent(new JacXsonTypeUpdated { JacXsonType = this });
    }

    public static JacXsonType Create(string name)
    {
        return new JacXsonType(Guid.NewGuid(), name);
    }

    public JacXsonType Update(string? name)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !Name.Equals(name))
        {
            Name = name;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new JacXsonType { JacXsonType = this });
        }

        return this;
    }
} 


