using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record UserSkillCreated : DomainEvent
{
    public UserSkill? UserSkill { get; set; }
}
