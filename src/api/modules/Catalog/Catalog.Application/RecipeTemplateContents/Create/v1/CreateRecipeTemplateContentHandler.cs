using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Create.v1;
public sealed class CreateRecipeTemplateContentHandler(
    ILogger<CreateRecipeTemplateContentHandler> logger,
    [FromKeyedServices("catalog:recipetemplatecontents")] IRepository<RecipeTemplateContent> repository)
    : IRequestHandler<CreateRecipeTemplateContentCommand, CreateRecipeTemplateContentResponse>
{
    public async Task<CreateRecipeTemplateContentResponse> Handle(CreateRecipeTemplateContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeTemplateContent = RecipeTemplateContent.Create(request.Content);        
        await repository.AddAsync(recipeTemplateContent, cancellationToken);
        logger.LogInformation("recipe template content created {RecipeTemplateContentId}", recipeTemplateContent.Id);
        return new CreateRecipeTemplateContentResponse(recipeTemplateContent.Id);
    }
}
