using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Update.v1;
public sealed class UpdateRecipeChangelogHandler(
    ILogger<UpdateRecipeChangelogHandler> logger,
    [FromKeyedServices("catalog:recipechangelogs")] IRepository<RecipeChangelog> repository)
    : IRequestHandler<UpdateRecipeChangelogCommand, UpdateRecipeChangelogResponse>
{
    public async Task<UpdateRecipeChangelogResponse> Handle(UpdateRecipeChangelogCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeChangelog = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeChangelog ?? throw new RecipeChangelogNotFoundException(request.Id);
        var updatedRecipeChangelog = recipeChangelog.Update(request.Content, request.Summary);
        await repository.UpdateAsync(updatedRecipeChangelog, cancellationToken);
        logger.LogInformation("recipe changelog with id : {RecipeChangelogId} updated.", recipeChangelog.Id);
        return new UpdateRecipeChangelogResponse(recipeChangelog.Id);
    }
}
