using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Create.v1;
public sealed class CreateRecipeHandler(
    ILogger<CreateRecipeHandler> logger,
    [FromKeyedServices("catalog:recipes")] IRepository<Recipe> repository)
    : IRequestHandler<CreateRecipeCommand, CreateRecipeResponse>
{
    public async Task<CreateRecipeResponse> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipe = Recipe.Create(request.Name!);
        await repository.AddAsync(recipe, cancellationToken);
        logger.LogInformation("recipe created {RecipeId}", recipe.Id);
        return new CreateRecipeResponse(recipe.Id);
    }
}
