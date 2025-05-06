using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Create.v1;
public sealed class CreateRecipeVersionHandler(
    ILogger<CreateRecipeVersionHandler> logger,
    [FromKeyedServices("catalog:recipeversions")] IRepository<RecipeVersion> repository)
    : IRequestHandler<CreateRecipeVersionCommand, CreateRecipeVersionResponse>
{
    public async Task<CreateRecipeVersionResponse> Handle(CreateRecipeVersionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var recipeVersion = RecipeVersion.Create(request.VersionNumber, request.Description, request.IsMandatory, request.ReleasedOn, request.UpdatedOn, request.Publisher); 
        await repository.AddAsync(recipeVersion, cancellationToken);
        logger.LogInformation("recipeVersion created {RecipeVersionId}", recipeVersion.Id);
        return new CreateRecipeVersionResponse(recipeVersion.Id);
    }
}
