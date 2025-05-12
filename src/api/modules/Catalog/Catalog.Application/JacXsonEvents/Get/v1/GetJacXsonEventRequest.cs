using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Get.v1;
public class GetJacXsonEventRequest : IRequest<JacXsonEventResponse>
{
    public Guid Id { get; set; }
    public GetJacXsonEventRequest(Guid id) => Id = id;
}
