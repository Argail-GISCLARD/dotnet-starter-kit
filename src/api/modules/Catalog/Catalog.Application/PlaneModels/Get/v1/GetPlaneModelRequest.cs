using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Get.v1;
public class GetPlaneModelRequest : IRequest<PlaneModelResponse>
{
    public Guid Id { get; set; }
    public GetPlaneModelRequest(Guid id) => Id = id;
}
