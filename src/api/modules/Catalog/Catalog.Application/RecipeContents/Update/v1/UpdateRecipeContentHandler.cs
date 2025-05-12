using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Update.v1;
public sealed class UpdateRecipeContentHandler(
    ILogger<UpdateRecipeContentHandler> logger,
    [FromKeyedServices("catalog:recipecontents")] IRepository<RecipeContent> repository)
    : IRequestHandler<UpdateRecipeContentCommand, UpdateRecipeContentResponse>
{
    public async Task<UpdateRecipeContentResponse> Handle(UpdateRecipeContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeContent = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeContent ?? throw new RecipeContentNotFoundException(request.Id);
        var updatedRecipeContent = recipeContent.Update(request.Content, request.Checksum);
        await repository.UpdateAsync(updatedRecipeContent, cancellationToken);
        logger.LogInformation("recipe content with id : {RecipeContentId} updated.", recipeContent.Id);
        return new UpdateRecipeContentResponse(recipeContent.Id);
    }
}
