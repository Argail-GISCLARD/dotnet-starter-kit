using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Get.v1;
public class GetRecipeContentRequest : IRequest<RecipeContentResponse>
{
    public Guid Id { get; set; }
    public GetRecipeContentRequest(Guid id) => Id = id;
}
