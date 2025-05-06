using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Delete.v1;
public sealed class DeleteRecipeVersionHandler(
    ILogger<DeleteRecipeVersionHandler> logger,
    [FromKeyedServices("catalog:recipeversions")] IRepository<RecipeVersion> repository)
    : IRequestHandler<DeleteRecipeVersionCommand>
{
    public async Task Handle(DeleteRecipeVersionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeVersion = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeVersion ?? throw new RecipeVersionNotFoundException(request.Id);
        await repository.DeleteAsync(recipeVersion, cancellationToken);
        logger.LogInformation("recipeVersion with id : {RecipeVersionId} deleted", recipeVersion.Id);
    }
}
