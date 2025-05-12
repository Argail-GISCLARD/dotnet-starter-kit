using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Delete.v1;
public sealed class DeleteRecipeTemplateContentHandler(
    ILogger<DeleteRecipeTemplateContentHandler> logger,
    [FromKeyedServices("catalog:recipetemplatecontents")] IRepository<RecipeTemplateContent> repository)
    : IRequestHandler<DeleteRecipeTemplateContentCommand>
{
    public async Task Handle(DeleteRecipeTemplateContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeTemplateContent = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeTemplateContent ?? throw new RecipeTemplateContentNotFoundException(request.Id);
        await repository.DeleteAsync(recipeTemplateContent, cancellationToken);
        logger.LogInformation("recipe template content with id : {RecipeTemplateContentId} deleted", recipeTemplateContent.Id);
    }
}
