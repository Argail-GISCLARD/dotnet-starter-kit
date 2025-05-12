using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Create.v1;
public sealed class CreatePlaneEngineHandler(
    ILogger<CreatePlaneEngineHandler> logger,
    [FromKeyedServices("catalog:planeengines")] IRepository<PlaneEngine> repository)
    : IRequestHandler<CreatePlaneEngineCommand, CreatePlaneEngineResponse>
{
    public async Task<CreatePlaneEngineResponse> Handle(CreatePlaneEngineCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeEngine = PlaneEngine.Create(request.Name);
        await repository.AddAsync(planeEngine, cancellationToken);
        logger.LogInformation("plane engine created {PlaneEngineId}", planeEngine.Id);
        return new CreatePlaneEngineResponse(planeEngine.Id);
    }
}
