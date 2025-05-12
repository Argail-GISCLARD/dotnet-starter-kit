using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Get.v1;
public sealed class GetSkillHandler(
    [FromKeyedServices("catalog:skills")] IReadRepository<Skill> repository,
    ICacheService cache)
    : IRequestHandler<GetSkillRequest, SkillResponse>
{
    public async Task<SkillResponse> Handle(GetSkillRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"skill:{request.Id}",
            async () =>
            {
                var skillItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (skillItem == null) throw new SkillNotFoundException(request.Id);
                return new SkillResponse(skillItem.Id, skillItem.Name, skillItem.IsPermanent, skillItem.Duration, skillItem.TenantId);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
