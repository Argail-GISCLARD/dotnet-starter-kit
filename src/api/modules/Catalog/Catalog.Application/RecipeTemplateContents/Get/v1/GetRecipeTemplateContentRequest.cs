using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Get.v1;
public class GetRecipeTemplateContentRequest : IRequest<RecipeTemplateContentResponse>
{
    public Guid Id { get; set; }
    public GetRecipeTemplateContentRequest(Guid id) => Id = id;
}
