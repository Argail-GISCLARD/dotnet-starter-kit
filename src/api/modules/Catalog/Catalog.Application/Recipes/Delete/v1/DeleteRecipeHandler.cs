using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Delete.v1;
public sealed class DeleteRecipeHandler(
    ILogger<DeleteRecipeHandler> logger,
    [FromKeyedServices("catalog:products")] IRepository<Recipe> repository)
    : IRequestHandler<DeleteRecipeCommand>
{
    public async Task Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipe = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipe ?? throw new RecipeNotFoundException(request.Id);
        await repository.DeleteAsync(recipe, cancellationToken);
        logger.LogInformation("recipe with id : {RecipeId} deleted", recipe.Id);
    }
}
