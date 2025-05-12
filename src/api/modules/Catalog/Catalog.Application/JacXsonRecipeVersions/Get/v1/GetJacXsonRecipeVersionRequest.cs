using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Get.v1;
public class GetJacXsonRecipeVersionRequest : IRequest<JacXsonRecipeVersionResponse>
{
    public Guid Id { get; set; }
    public GetJacXsonRecipeVersionRequest(Guid id) => Id = id;
}
