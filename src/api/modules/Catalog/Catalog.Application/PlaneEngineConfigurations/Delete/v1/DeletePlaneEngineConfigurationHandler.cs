using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Delete.v1;
public sealed class DeletePlaneEngineConfigurationHandler(
    ILogger<DeletePlaneEngineConfigurationHandler> logger,
    [FromKeyedServices("catalog:planeengineconfigurations")] IRepository<PlaneEngineConfiguration> repository)
    : IRequestHandler<DeletePlaneEngineConfigurationCommand>
{
    public async Task Handle(DeletePlaneEngineConfigurationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var PlaneEngineConfiguration = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = PlaneEngineConfiguration ?? throw new PlaneEngineConfigurationNotFoundException(request.Id);
        await repository.DeleteAsync(PlaneEngineConfiguration, cancellationToken);
        logger.LogInformation("plane engine configuration with id : {PlaneEngineConfigurationId} deleted", PlaneEngineConfiguration.Id);
    }
}
