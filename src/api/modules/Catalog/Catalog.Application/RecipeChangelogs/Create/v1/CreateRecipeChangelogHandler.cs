using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Create.v1;
public sealed class CreateRecipeChangelogHandler(
    ILogger<CreateRecipeChangelogHandler> logger,
    [FromKeyedServices("catalog:recipechangelogs")] IRepository<RecipeChangelog> repository)
    : IRequestHandler<CreateRecipeChangelogCommand, CreateRecipeChangelogResponse>
{
    public async Task<CreateRecipeChangelogResponse> Handle(CreateRecipeChangelogCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeChangelog = RecipeChangelog.Create(request.Content, request.Summary);        
        await repository.AddAsync(recipeChangelog, cancellationToken);
        logger.LogInformation("recipe changelog created {RecipeChangelogId}", recipeChangelog.Id);
        return new CreateRecipeChangelogResponse(recipeChangelog.Id);
    }
}
