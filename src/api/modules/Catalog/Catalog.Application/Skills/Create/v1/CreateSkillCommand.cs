using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Create.v1;
public sealed record CreateSkillCommand(
    [property: DefaultValue("Skill Name")] string Name,
    [property: DefaultValue("1.03:14:56.1667")] TimeSpan Duration,
    [property: DefaultValue("0")] string TenantId,
    [property: DefaultValue(false)] bool IsPermanent)
    : IRequest<CreateSkillResponse>;

