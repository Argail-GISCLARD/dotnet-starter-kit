using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Delete.v1;
public sealed class DeleteRecipeStatusHandler(
    ILogger<DeleteRecipeStatusHandler> logger,
    [FromKeyedServices("catalog:recipestatuses")] IRepository<RecipeStatus> repository)
    : IRequestHandler<DeleteRecipeStatusCommand>
{
    public async Task Handle(DeleteRecipeStatusCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeStatus = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeStatus ?? throw new RecipeStatusNotFoundException(request.Id);
        await repository.DeleteAsync(recipeStatus, cancellationToken);
        logger.LogInformation("recipe status with id : {RecipeStatusId} deleted", recipeStatus.Id);
    }
}
