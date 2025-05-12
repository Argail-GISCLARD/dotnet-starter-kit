using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Update.v1;
public sealed record UpdateSkillCommand(
    Guid Id,
    string? Name,
    string? TenantId,
    TimeSpan? Duration,
    bool? IsPermanent) : IRequest<UpdateSkillResponse>;
