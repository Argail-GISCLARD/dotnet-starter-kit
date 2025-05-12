using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Create.v1;
public sealed class CreateSkillHandler(
    ILogger<CreateSkillHandler> logger,
    [FromKeyedServices("catalog:skills")] IRepository<Skill> repository)
    : IRequestHandler<CreateSkillCommand, CreateSkillResponse>
{
    public async Task<CreateSkillResponse> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var skill = Skill.Create(request.Name, request.IsPermanent, request.TenantId, request.Duration);
        await repository.AddAsync(skill, cancellationToken);
        logger.LogInformation("skill created {SkillId}", skill.Id);
        return new CreateSkillResponse(skill.Id);
    }
}
