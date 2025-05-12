using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Get.v1;
public sealed class GetRecipeTemplateHandler(
    [FromKeyedServices("catalog:recipetemplates")] IReadRepository<RecipeTemplate> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeTemplateRequest, RecipeTemplateResponse>
{
    public async Task<RecipeTemplateResponse> Handle(GetRecipeTemplateRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipetemplate:{request.Id}",
            async () =>
            {
                var recipeTemplateItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (recipeTemplateItem == null) throw new RecipeTemplateNotFoundException(request.Id);
                return new RecipeTemplateResponse(recipeTemplateItem.Id, recipeTemplateItem.VersionNumber, recipeTemplateItem.Description, recipeTemplateItem.IsMandatory, recipeTemplateItem.RealeasedOn, recipeTemplateItem.UpdatedOn, recipeTemplateItem.Publisher, recipeTemplateItem.RecipeTemplateContentId);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
