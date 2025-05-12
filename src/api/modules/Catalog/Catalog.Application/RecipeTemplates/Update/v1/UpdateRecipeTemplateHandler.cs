using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Update.v1;
public sealed class UpdateRecipeTemplateHandler(
    ILogger<UpdateRecipeTemplateHandler> logger,
    [FromKeyedServices("catalog:recipetemplates")] IRepository<RecipeTemplate> repository)
    : IRequestHandler<UpdateRecipeTemplateCommand, UpdateRecipeTemplateResponse>
{
    public async Task<UpdateRecipeTemplateResponse> Handle(UpdateRecipeTemplateCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeTemplate = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeTemplate ?? throw new RecipeTemplateNotFoundException(request.Id);
        var updatedRecipeTemplate = recipeTemplate
            .Update(
            request.VersionNumber, 
            request.Description, 
            request.IsMandatory,
            request.IsPaid,
            request.ReleasedOn, 
            request.UpdatedOn, 
            request.Publisher,
            request.RecipeTemplateContentId);
        await repository.UpdateAsync(updatedRecipeTemplate, cancellationToken);
        logger.LogInformation("recipe template with id : {RecipeTemplateId} updated.", recipeTemplate.Id);
        return new UpdateRecipeTemplateResponse(recipeTemplate.Id);
    }
}
