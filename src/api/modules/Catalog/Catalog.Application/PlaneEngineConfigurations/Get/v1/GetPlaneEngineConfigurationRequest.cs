using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Get.v1;
public class GetPlaneEngineConfigurationRequest : IRequest<PlaneEngineConfigurationResponse>
{
    public Guid Id { get; set; }
    public GetPlaneEngineConfigurationRequest(Guid id) => Id = id;
}
