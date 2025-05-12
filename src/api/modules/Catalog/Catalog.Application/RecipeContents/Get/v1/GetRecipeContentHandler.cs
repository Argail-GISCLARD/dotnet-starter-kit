using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Get.v1;
public sealed class GetRecipeContentHandler(
    [FromKeyedServices("catalog:recipecontents")] IReadRepository<RecipeContent> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeContentRequest, RecipeContentResponse>
{
    public async Task<RecipeContentResponse> Handle(GetRecipeContentRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipecontent:{request.Id}",
            async () =>
            {
                var recipeContentItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (recipeContentItem == null) throw new RecipeContentNotFoundException(request.Id);
                return new RecipeContentResponse(recipeContentItem.Id, recipeContentItem.Content, recipeContentItem.Checksum);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
