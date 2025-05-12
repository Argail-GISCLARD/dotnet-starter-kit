using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Create.v1;
public sealed class CreateRecipeTemplateHandler(
    ILogger<CreateRecipeTemplateHandler> logger,
    [FromKeyedServices("catalog:recipetemplates")] IRepository<RecipeTemplate> repository)
    : IRequestHandler<CreateRecipeTemplateCommand, CreateRecipeTemplateResponse>
{
    public async Task<CreateRecipeTemplateResponse> Handle(CreateRecipeTemplateCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeTemplate = RecipeTemplate.Create(
            request.VersionNumber, 
            request.Description, 
            request.IsMandatory, 
            request.IsPaid, 
            request.ReleasedOn, 
            request.UpdatedOn, 
            request.Publisher, 
            request.RecipeTemplateContentId);
        
        await repository.AddAsync(recipeTemplate, cancellationToken);
        logger.LogInformation("recipe template created {RecipeTemplateId}", recipeTemplate.Id);
        return new CreateRecipeTemplateResponse(recipeTemplate.Id);
    }
}
