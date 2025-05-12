using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Create.v1;
public sealed class CreateRecipeContentHandler(
    ILogger<CreateRecipeContentHandler> logger,
    [FromKeyedServices("catalog:recipecontents")] IRepository<RecipeContent> repository)
    : IRequestHandler<CreateRecipeContentCommand, CreateRecipeContentResponse>
{
    public async Task<CreateRecipeContentResponse> Handle(CreateRecipeContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeContent = RecipeContent.Create(request.Content, request.Checksum);        
        await repository.AddAsync(recipeContent, cancellationToken);
        logger.LogInformation("recipe content created {RecipeContentId}", recipeContent.Id);
        return new CreateRecipeContentResponse(recipeContent.Id);
    }
}
