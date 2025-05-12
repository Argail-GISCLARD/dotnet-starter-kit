using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Get.v1;
public class GetPlaneEngineRequest : IRequest<PlaneEngineResponse>
{
    public Guid Id { get; set; }
    public GetPlaneEngineRequest(Guid id) => Id = id;
}
