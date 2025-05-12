using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Get.v1;
public class GetRecipeStatusRequest : IRequest<RecipeStatusResponse>
{
    public Guid Id { get; set; }
    public GetRecipeStatusRequest(Guid id) => Id = id;
}
