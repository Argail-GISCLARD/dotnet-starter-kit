using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Get.v1;
public class GetRecipeTemplateRequest : IRequest<RecipeTemplateResponse>
{
    public Guid Id { get; set; }
    public GetRecipeTemplateRequest(Guid id) => Id = id;
}
