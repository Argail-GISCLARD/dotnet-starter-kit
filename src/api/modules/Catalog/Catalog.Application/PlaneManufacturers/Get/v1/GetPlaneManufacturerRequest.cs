using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Get.v1;
public class GetPlaneManufacturerRequest : IRequest<PlaneManufacturerResponse>
{
    public Guid Id { get; set; }
    public GetPlaneManufacturerRequest(Guid id) => Id = id;
}
