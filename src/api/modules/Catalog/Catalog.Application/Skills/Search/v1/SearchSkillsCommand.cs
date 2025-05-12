using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Skills.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Search.v1;

public class SearchSkillsCommand : PaginationFilter, IRequest<PagedList<SkillResponse>>
{
    public string? TenantId { get; set; }
    public bool? IsPermanent{ get; set; }
}
