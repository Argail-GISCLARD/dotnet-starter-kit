using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
public class GetRecipeVersionRequest : IRequest<RecipeVersionResponse>
{
    public Guid Id { get; set; }
    public GetRecipeVersionRequest(Guid id) => Id = id;
}
