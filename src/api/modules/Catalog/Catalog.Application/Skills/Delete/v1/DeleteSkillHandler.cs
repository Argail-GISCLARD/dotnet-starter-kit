using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Delete.v1;
public sealed class DeleteSkillHandler(
    ILogger<DeleteSkillHandler> logger,
    [FromKeyedServices("catalog:skills")] IRepository<Skill> repository)
    : IRequestHandler<DeleteSkillCommand>
{
    public async Task Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var skill = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = skill ?? throw new SkillNotFoundException(request.Id);
        await repository.DeleteAsync(skill, cancellationToken);
        logger.LogInformation("skill with id : {SkillId} deleted", skill.Id);
    }
}
