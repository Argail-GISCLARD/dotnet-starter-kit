using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Create.v1;
public sealed class CreateRecipeStatusHandler(
    ILogger<CreateRecipeStatusHandler> logger,
    [FromKeyedServices("catalog:recipestatuses")] IRepository<RecipeStatus> repository)
    : IRequestHandler<CreateRecipeStatusCommand, CreateRecipeStatusResponse>
{
    public async Task<CreateRecipeStatusResponse> Handle(CreateRecipeStatusCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeStatus = RecipeStatus.Create(request.Status, request.ManufacturerDecisionOn, request.ExcentDecisionOn);        
        await repository.AddAsync(recipeStatus, cancellationToken);
        logger.LogInformation("recipe status created {RecipeStatusId}", recipeStatus.Id);
        return new CreateRecipeStatusResponse(recipeStatus.Id);
    }
}
