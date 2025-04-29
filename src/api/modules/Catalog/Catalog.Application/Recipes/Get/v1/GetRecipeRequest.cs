using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
public class GetRecipeRequest : IRequest<RecipeResponse>
{
    public Guid Id { get; set; }
    public GetRecipeRequest(Guid id) => Id = id;
}
