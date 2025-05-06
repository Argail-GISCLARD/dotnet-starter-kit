using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
public sealed class GetRecipeVersionHandler(
    [FromKeyedServices("catalog:recipeversions")] IReadRepository<RecipeVersion> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeVersionRequest, RecipeVersionResponse>
{
    public async Task<RecipeVersionResponse> Handle(GetRecipeVersionRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipeversion:{request.Id}",
            async () =>
            {
                var recipeVersionItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (recipeVersionItem == null) throw new RecipeVersionNotFoundException(request.Id);
                return new RecipeVersionResponse(recipeVersionItem.Id, recipeVersionItem.VersionNumber, recipeVersionItem.Description, recipeVersionItem.IsMandatory, recipeVersionItem.RealeasedOn, recipeVersionItem.UpdatedOn, recipeVersionItem.Publisher);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
