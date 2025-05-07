using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record UserSkillUpdated : DomainEvent
{
    public UserSkill? UserSkill { get; set; }
}
