using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Delete.v1;
public sealed class DeleteRecipeTemplateHandler(
    ILogger<DeleteRecipeTemplateHandler> logger,
    [FromKeyedServices("catalog:recipetemplates")] IRepository<RecipeTemplate> repository)
    : IRequestHandler<DeleteRecipeTemplateCommand>
{
    public async Task Handle(DeleteRecipeTemplateCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeTemplate = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeTemplate ?? throw new RecipeTemplateNotFoundException(request.Id);
        await repository.DeleteAsync(recipeTemplate, cancellationToken);
        logger.LogInformation("recipe template with id : {RecipeTemplateId} deleted", recipeTemplate.Id);
    }
}
