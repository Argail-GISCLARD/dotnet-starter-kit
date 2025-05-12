using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Delete.v1;
public sealed class DeleteRecipeChangelogHandler(
    ILogger<DeleteRecipeChangelogHandler> logger,
    [FromKeyedServices("catalog:recipechangelogs")] IRepository<RecipeChangelog> repository)
    : IRequestHandler<DeleteRecipeChangelogCommand>
{
    public async Task Handle(DeleteRecipeChangelogCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeChangelog = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeChangelog ?? throw new RecipeChangelogNotFoundException(request.Id);
        await repository.DeleteAsync(recipeChangelog, cancellationToken);
        logger.LogInformation("recipe changelog with id : {RecipeChangelogId} deleted", recipeChangelog.Id);
    }
}
