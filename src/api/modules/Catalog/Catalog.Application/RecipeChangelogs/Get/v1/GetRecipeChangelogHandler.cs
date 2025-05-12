using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Get.v1;
public sealed class GetRecipeChangelogHandler(
    [FromKeyedServices("catalog:recipechangelogs")] IReadRepository<RecipeChangelog> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeChangelogRequest, RecipeChangelogResponse>
{
    public async Task<RecipeChangelogResponse> Handle(GetRecipeChangelogRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipechangelog:{request.Id}",
            async () =>
            {
                var recipeChangelogItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (recipeChangelogItem == null) throw new RecipeChangelogNotFoundException(request.Id);
                return new RecipeChangelogResponse(recipeChangelogItem.Id, recipeChangelogItem.Content, recipeChangelogItem.Summary);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
