using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Get.v1;
public class GetJacXsonTypeRequest : IRequest<JacXsonTypeResponse>
{
    public Guid Id { get; set; }
    public GetJacXsonTypeRequest(Guid id) => Id = id;
}
