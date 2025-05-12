using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Delete.v1;
public sealed class DeleteRecipeContentHandler(
    ILogger<DeleteRecipeContentHandler> logger,
    [FromKeyedServices("catalog:recipecontents")] IRepository<RecipeContent> repository)
    : IRequestHandler<DeleteRecipeContentCommand>
{
    public async Task Handle(DeleteRecipeContentCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeContent = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = recipeContent ?? throw new RecipeContentNotFoundException(request.Id);
        await repository.DeleteAsync(recipeContent, cancellationToken);
        logger.LogInformation("recipe content with id : {RecipeContentId} deleted", recipeContent.Id);
    }
}
