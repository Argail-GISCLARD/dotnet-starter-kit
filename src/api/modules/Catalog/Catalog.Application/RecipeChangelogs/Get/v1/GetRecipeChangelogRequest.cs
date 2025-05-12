using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Get.v1;
public class GetRecipeChangelogRequest : IRequest<RecipeChangelogResponse>
{
    public Guid Id { get; set; }
    public GetRecipeChangelogRequest(Guid id) => Id = id;
}
