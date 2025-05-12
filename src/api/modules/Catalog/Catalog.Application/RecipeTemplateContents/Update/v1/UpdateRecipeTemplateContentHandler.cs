using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Update.v1;
public sealed class UpdateRecipeTemplateContentHandler(
    ILogger<UpdateRecipeTemplateContentHandler> logger,
    [FromKeyedServices("catalog:recipetemplatecontents")] IRepository<RecipeTemplateContent> repository)
    : IRequestHandler<UpdateRecipeTemplateContentCommand, UpdateRecipeTemplateContentResponse>
{
    public async Task<UpdateRecipeTemplateContentResponse> Handle(UpdateRecipeTemplateContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeTemplateContent = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeTemplateContent ?? throw new RecipeTemplateContentNotFoundException(request.Id);
        var updatedRecipeTemplateContent = recipeTemplateContent.Update(request.Content);
        await repository.UpdateAsync(updatedRecipeTemplateContent, cancellationToken);
        logger.LogInformation("recipe template content with id : {RecipeTemplateContentId} updated.", recipeTemplateContent.Id);
        return new UpdateRecipeTemplateContentResponse(recipeTemplateContent.Id);
    }
}
