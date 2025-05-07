using FSH.Framework.Core.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain.Events;
public sealed record SkillCreated : DomainEvent
{
    public Skill? Skill { get; set; }
}
