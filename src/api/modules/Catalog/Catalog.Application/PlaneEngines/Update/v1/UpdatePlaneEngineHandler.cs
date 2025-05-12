using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Update.v1;
public sealed class UpdatePlaneEngineHandler(
    ILogger<UpdatePlaneEngineHandler> logger,
    [FromKeyedServices("catalog:planeengines")] IRepository<PlaneEngine> repository)
    : IRequestHandler<UpdatePlaneEngineCommand, UpdatePlaneEngineResponse>
{
    public async Task<UpdatePlaneEngineResponse> Handle(UpdatePlaneEngineCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeEngine = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = planeEngine ?? throw new PlaneEngineNotFoundException(request.Id);
        var updatedPlaneEngine = planeEngine.Update(request.Name);
        await repository.UpdateAsync(updatedPlaneEngine, cancellationToken);
        logger.LogInformation("plane engine with id : {PlaneEngineId} updated.", planeEngine.Id);
        return new UpdatePlaneEngineResponse(planeEngine.Id);
    }
}
