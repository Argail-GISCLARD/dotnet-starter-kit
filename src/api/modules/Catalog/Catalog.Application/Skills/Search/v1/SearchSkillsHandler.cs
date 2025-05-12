using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Skills.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Search.v1;
public sealed class SearchSkillsHandler(
    [FromKeyedServices("catalog:skills")] IReadRepository<Skill> repository)
    : IRequestHandler<SearchSkillsCommand, PagedList<SkillResponse>>
{
    public async Task<PagedList<SkillResponse>> Handle(SearchSkillsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchSkillSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<SkillResponse>(items, request!.PageNumber, request!.PageSize, totalCount);
    }
}
