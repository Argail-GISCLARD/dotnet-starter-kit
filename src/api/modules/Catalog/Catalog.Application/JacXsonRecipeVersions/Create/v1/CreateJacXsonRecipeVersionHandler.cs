using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Create.v1;
public sealed class CreateJacXsonRecipeVersionHandler(
    ILogger<CreateJacXsonRecipeVersionHandler> logger,
    [FromKeyedServices("catalog:jacxsonrecipeversions")] IRepository<JacXsonRecipeVersion> repository)
    : IRequestHandler<CreateJacXsonRecipeVersionCommand, CreateJacXsonRecipeVersionResponse>
{
    public async Task<CreateJacXsonRecipeVersionResponse> Handle(CreateJacXsonRecipeVersionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonRecipeVersion = JacXsonRecipeVersion.Create(request.InstalledOn, request.InstalledBy, request.JacXsonId, request.RecipeId);
        await repository.AddAsync(jacXsonRecipeVersion, cancellationToken);
        logger.LogInformation("jacxson recipe version created {JacXsonRecipeVersionId}", jacXsonRecipeVersion.Id);
        return new CreateJacXsonRecipeVersionResponse(jacXsonRecipeVersion.Id);
    }
}
