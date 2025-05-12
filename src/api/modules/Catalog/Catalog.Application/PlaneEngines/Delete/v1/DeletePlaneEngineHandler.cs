using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Delete.v1;
public sealed class DeletePlaneEngineHandler(
    ILogger<DeletePlaneEngineHandler> logger,
    [FromKeyedServices("catalog:planeengines")] IRepository<PlaneEngine> repository)
    : IRequestHandler<DeletePlaneEngineCommand>
{
    public async Task Handle(DeletePlaneEngineCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var PlaneEngine = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = PlaneEngine ?? throw new PlaneEngineNotFoundException(request.Id);
        await repository.DeleteAsync(PlaneEngine, cancellationToken);
        logger.LogInformation("plane engine with id : {PlaneEngineId} deleted", PlaneEngine.Id);
    }
}
