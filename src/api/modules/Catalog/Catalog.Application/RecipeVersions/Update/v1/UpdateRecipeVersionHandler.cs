using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Update.v1;
public sealed class UpdateRecipeVersionHandler(
    ILogger<UpdateRecipeVersionHandler> logger,
    [FromKeyedServices("catalog:recipeversions")] IRepository<RecipeVersion> repository)
    : IRequestHandler<UpdateRecipeVersionCommand, UpdateRecipeVersionResponse>
{
    public async Task<UpdateRecipeVersionResponse> Handle(UpdateRecipeVersionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeVersion = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeVersion ?? throw new RecipeVersionNotFoundException(request.Id);
        var updatedRecipeVersion = recipeVersion
            .Update(
            request.VersionNumber, 
            request.Description, 
            request.IsMandatory,
            request.IsPaid,
            request.ReleasedOn, 
            request.UpdatedOn, 
            request.Publisher, 
            request.Operations, 
            request.RecipeId, 
            request.JacXsonTypeId, 
            request.RecipeStatusId, 
            request.RecipeContentId,
            request.RecipeChangelogId,
            request.JacXsonRecipeVersions,
            request.Skills);
        await repository.UpdateAsync(updatedRecipeVersion, cancellationToken);
        logger.LogInformation("recipeVersion with id : {RecipeVersionId} updated.", recipeVersion.Id);
        return new UpdateRecipeVersionResponse(recipeVersion.Id);
    }
}
