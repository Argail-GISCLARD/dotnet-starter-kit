using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Update.v1;
public sealed class UpdatePlaneEngineConfigurationHandler(
    ILogger<UpdatePlaneEngineConfigurationHandler> logger,
    [FromKeyedServices("catalog:planeengineconfigurations")] IRepository<PlaneEngineConfiguration> repository)
    : IRequestHandler<UpdatePlaneEngineConfigurationCommand, UpdatePlaneEngineConfigurationResponse>
{
    public async Task<UpdatePlaneEngineConfigurationResponse> Handle(UpdatePlaneEngineConfigurationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var PlaneEngineConfiguration = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = PlaneEngineConfiguration ?? throw new PlaneEngineConfigurationNotFoundException(request.Id);
        var updatedPlaneEngineConfiguration = PlaneEngineConfiguration.Update(request.Name);
        await repository.UpdateAsync(updatedPlaneEngineConfiguration, cancellationToken);
        logger.LogInformation("plane engine configuration with id : {PlaneEngineConfigurationId} updated.", PlaneEngineConfiguration.Id);
        return new UpdatePlaneEngineConfigurationResponse(PlaneEngineConfiguration.Id);
    }
}
