using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
public sealed class GetRecipeHandler(
    [FromKeyedServices("catalog:recipes")] IReadRepository<Recipe> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeRequest, RecipeResponse>
{
    public async Task<RecipeResponse> Handle(GetRecipeRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipe:{request.Id}",
            async () =>
            {
                var spec = new GetRecipeSpecs(request.Id);
                var recipeItem = await repository.FirstOrDefaultAsync(spec, cancellationToken);
                if (recipeItem == null) throw new RecipeNotFoundException(request.Id);
                return recipeItem;
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
