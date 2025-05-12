using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.Skills.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Search.v1;
public class SearchSkillSpecs : EntitiesByPaginationFilterSpec<Skill, SkillResponse>
{
    public SearchSkillSpecs(SearchSkillsCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.Name, !command.HasOrderBy())
            .Where(b => b.Name.Contains(command.Keyword), !string.IsNullOrEmpty(command.Keyword))
            .Where(b => b.TenantId.Contains(command.TenantId), !string.IsNullOrEmpty(command.TenantId))
            .Where(b => b.IsPermanent == command.IsPermanent!, command.IsPermanent.HasValue);
}
