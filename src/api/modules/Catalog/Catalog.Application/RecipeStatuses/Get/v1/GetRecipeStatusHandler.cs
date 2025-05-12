using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Get.v1;
public sealed class GetRecipeStatusHandler(
    [FromKeyedServices("catalog:recipestatuss")] IReadRepository<RecipeStatus> repository,
    ICacheService cache)
    : IRequestHandler<GetRecipeStatusRequest, RecipeStatusResponse>
{
    public async Task<RecipeStatusResponse> Handle(GetRecipeStatusRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"recipestatus:{request.Id}",
            async () =>
            {
                var recipeStatusItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (recipeStatusItem == null) throw new RecipeStatusNotFoundException(request.Id);
                return new RecipeStatusResponse(recipeStatusItem.Id, recipeStatusItem.Status, recipeStatusItem.ManufacturerDecisionOn, recipeStatusItem.ExcenDecisionOn);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
