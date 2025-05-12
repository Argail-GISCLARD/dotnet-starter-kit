using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Get.v1;
public sealed class GetJacXsonRecipeVersionHandler(
    [FromKeyedServices("catalog:jacxsonrecipeversions")] IReadRepository<JacXsonRecipeVersion> repository,
    ICacheService cache)
    : IRequestHandler<GetJacXsonRecipeVersionRequest, JacXsonRecipeVersionResponse>
{
    public async Task<JacXsonRecipeVersionResponse> Handle(GetJacXsonRecipeVersionRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var item = await cache.GetOrSetAsync(
            $"jacxsonrecipeversion:{request.Id}",
            async () =>
            {
                var jacXsonRecipeVersionItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (jacXsonRecipeVersionItem == null) throw new JacXsonRecipeVersionNotFoundException(request.Id);
                return new JacXsonRecipeVersionResponse(jacXsonRecipeVersionItem.Id, jacXsonRecipeVersionItem.InstalledBy, jacXsonRecipeVersionItem.InstalledOn, jacXsonRecipeVersionItem.JacXsonId, jacXsonRecipeVersionItem.RecipeId);
            },
            cancellationToken: cancellationToken);
        return item!;
    }
}
