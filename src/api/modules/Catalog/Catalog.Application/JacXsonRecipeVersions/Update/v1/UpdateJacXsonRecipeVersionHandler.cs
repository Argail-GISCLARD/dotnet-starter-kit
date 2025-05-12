using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Update.v1;
public sealed class UpdateJacXsonRecipeVersionHandler(
    ILogger<UpdateJacXsonRecipeVersionHandler> logger,
    [FromKeyedServices("catalog:jacxsonrecipeversions")] IRepository<JacXsonRecipeVersion> repository)
    : IRequestHandler<UpdateJacXsonRecipeVersionCommand, UpdateJacXsonRecipeVersionResponse>
{
    public async Task<UpdateJacXsonRecipeVersionResponse> Handle(UpdateJacXsonRecipeVersionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonRecipeVersion = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXsonRecipeVersion ?? throw new JacXsonRecipeVersionNotFoundException(request.Id);
        var updatedJacXsonRecipeVersion = jacXsonRecipeVersion.Update(request.InstalledOn, request.InstalledBy, request.JacXsonId, request.RecipeId);
        await repository.UpdateAsync(updatedJacXsonRecipeVersion, cancellationToken);
        logger.LogInformation("jacxson recipe version with id : {JacXsonRecipeVersionId} updated.", jacXsonRecipeVersion.Id);
        return new UpdateJacXsonRecipeVersionResponse(jacXsonRecipeVersion.Id);
    }
}
