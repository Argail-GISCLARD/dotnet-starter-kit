using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record SkillUpdated : DomainEvent
{
    public Skill? Skill { get; set; }
}
