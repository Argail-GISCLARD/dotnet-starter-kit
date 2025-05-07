using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Skill : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public bool IsPermanent { get; private set; } = false;
    public string TenantId { get; private set; } = string.Empty;
    public TimeSpan Duration { get; private set; } = TimeSpan.Zero;

    private Skill() { }

    private Skill(Guid id, string name, bool isPermanent, string tenantId, TimeSpan duration)
    {
        Id = id;
        Name = name;
        IsPermanent = isPermanent;
        TenantId = tenantId;
        Duration = duration;
        QueueDomainEvent(new SkillCreated { Skill = this });
    }

    public static Skill Create(string name, bool isPermanent, string tenantId, TimeSpan duration)
    {
        return new Skill(Guid.NewGuid(), name, isPermanent, tenantId, duration);
    }

    public Skill Update(string? name, bool? isPermanent, string? tenantId, TimeSpan? duration)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(name) && !string.Equals(Name, name, StringComparison.OrdinalIgnoreCase))
        {
            Name = name;
            isUpdated = true;
        }

        if (isPermanent.HasValue && IsPermanent != isPermanent.Value)
        {
            IsPermanent = isPermanent.Value;
            isUpdated = true;
        }

        if (!string.IsNullOrWhiteSpace(tenantId) && !string.Equals(TenantId, tenantId, StringComparison.OrdinalIgnoreCase))
        {
            TenantId = tenantId;
            isUpdated = true;
        }

        if (duration.HasValue && Duration != duration.Value)
        {
            Duration = duration.Value;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new SkillUpdated { Skill = this });
        }

        return this;
    }
}
