using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Delete.v1;
public sealed class DeleteJacXsonRecipeVersionHandler(
    ILogger<DeleteJacXsonRecipeVersionHandler> logger,
    [FromKeyedServices("catalog:jacxsonrecipeversions")] IRepository<JacXsonRecipeVersion> repository)
    : IRequestHandler<DeleteJacXsonRecipeVersionCommand>
{
    public async Task Handle(DeleteJacXsonRecipeVersionCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonRecipeVersion = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXsonRecipeVersion ?? throw new JacXsonRecipeVersionNotFoundException(request.Id);
        await repository.DeleteAsync(jacXsonRecipeVersion, cancellationToken);
        logger.LogInformation("jacxson recipe version with id : {JacXsonRecipeVersionId} deleted", jacXsonRecipeVersion.Id);
    }
}
