using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class UserSkill : AuditableEntity, IAggregateRoot
{
    public DateTime ObtainedOn { get; private set; } = DateTime.UtcNow;
    public int State { get; private set; } = 0;

    private UserSkill() { }

    private UserSkill(Guid id, DateTime obtainedOn, int state)
    {
        Id = id;
        ObtainedOn = obtainedOn;
        State = state;
        QueueDomainEvent(new UserSkillCreated { UserSkill = this });
    }

    public static UserSkill Create(DateTime obtainedOn, int state)
    {
        return new UserSkill(Guid.NewGuid(), obtainedOn, state);
    }

    public UserSkill Update(DateTime? obtainedOn, int? state)
    {
        bool isUpdated = false;

        if (obtainedOn.HasValue && ObtainedOn != obtainedOn.Value)
        {
            ObtainedOn = obtainedOn.Value;
            isUpdated = true;
        }

        if (state.HasValue && State != state.Value)
        {
            State = state.Value;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new UserSkillUpdated { UserSkill = this });
        }

        return this;
    }
}
