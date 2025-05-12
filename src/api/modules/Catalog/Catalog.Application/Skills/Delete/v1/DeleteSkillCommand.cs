using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Delete.v1;
public sealed record DeleteSkillCommand(
    Guid Id) : IRequest;
