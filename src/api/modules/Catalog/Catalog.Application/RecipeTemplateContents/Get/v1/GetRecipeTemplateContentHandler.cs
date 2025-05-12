using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Get.v1;
public sealed class GetRecipeTemplateContentHandler(
    [FromKeyedServices("catalog:recipetemplatecontents")] IReadRepository<RecipeTemplateContent> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeTemplateContentRequest, RecipeTemplateContentResponse>
{
    public async Task<RecipeTemplateContentResponse> Handle(GetRecipeTemplateContentRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipetemplatecontent:{request.Id}",
            async () =>
            {
                var recipeTemplateContentItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (recipeTemplateContentItem == null) throw new RecipeTemplateContentNotFoundException(request.Id);
                return new RecipeTemplateContentResponse(recipeTemplateContentItem.Id, recipeTemplateContentItem.Content);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
