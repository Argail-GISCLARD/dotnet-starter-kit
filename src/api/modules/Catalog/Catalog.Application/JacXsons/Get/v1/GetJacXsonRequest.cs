using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Get.v1;
public class GetJacXsonRequest : IRequest<JacXsonResponse>
{
    public Guid Id { get; set; }
    public GetJacXsonRequest(Guid id) => Id = id;
}
