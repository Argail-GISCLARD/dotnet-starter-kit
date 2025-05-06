using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Update.v1;
public sealed class UpdateRecipeHandler(
    ILogger<UpdateRecipeHandler> logger,
    [FromKeyedServices("catalog:recipes")] IRepository<Recipe> repository)
    : IRequestHandler<UpdateRecipeCommand, UpdateRecipeResponse>
{
    public async Task<UpdateRecipeResponse> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipe = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipe ?? throw new BrandNotFoundException(request.Id);
        var updatedBrand = recipe.Update(request.Name);
        await repository.UpdateAsync(updatedBrand, cancellationToken);
        logger.LogInformation("Recipe with id : {RecipeId} updated.", recipe.Id);
        return new UpdateRecipeResponse(recipe.Id);
    }
}
