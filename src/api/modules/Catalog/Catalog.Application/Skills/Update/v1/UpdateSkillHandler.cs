using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Update.v1;
public sealed class UpdateSkillHandler(
    ILogger<UpdateSkillHandler> logger,
    [FromKeyedServices("catalog:skills")] IRepository<Skill> repository)
    : IRequestHandler<UpdateSkillCommand, UpdateSkillResponse>
{
    public async Task<UpdateSkillResponse> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var skill = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = skill ?? throw new SkillNotFoundException(request.Id);
        var updatedSkill = skill.Update(skill.Name, skill.IsPermanent, skill.TenantId, skill.Duration);
        await repository.UpdateAsync(updatedSkill, cancellationToken);
        logger.LogInformation("skill with id : {SkillId} updated.", skill.Id);
        return new UpdateSkillResponse(skill.Id);
    }
}
