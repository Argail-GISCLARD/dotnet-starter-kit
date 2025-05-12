using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Update.v1;
public sealed class UpdateRecipeStatusHandler(
    ILogger<UpdateRecipeStatusHandler> logger,
    [FromKeyedServices("catalog:recipestatuses")] IRepository<RecipeStatus> repository)
    : IRequestHandler<UpdateRecipeStatusCommand, UpdateRecipeStatusResponse>
{
    public async Task<UpdateRecipeStatusResponse> Handle(UpdateRecipeStatusCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeStatus = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeStatus ?? throw new RecipeStatusNotFoundException(request.Id);
        var updatedRecipeStatus = recipeStatus.Update(request.Status, request.ManufacturerDecisionOn, request.ExcentDecisionOn);
        await repository.UpdateAsync(updatedRecipeStatus, cancellationToken);
        logger.LogInformation("recipe status with id : {RecipeStatusId} updated.", recipeStatus.Id);
        return new UpdateRecipeStatusResponse(recipeStatus.Id);
    }
}
