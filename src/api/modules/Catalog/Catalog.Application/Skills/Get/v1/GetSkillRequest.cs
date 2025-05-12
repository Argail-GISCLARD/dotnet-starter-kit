using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Get.v1;
public class GetSkillRequest : IRequest<SkillResponse>
{
    public Guid Id { get; set; }
    public GetSkillRequest(Guid id) => Id = id;
}
