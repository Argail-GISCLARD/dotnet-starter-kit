using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Create.v1;
public sealed class CreatePlaneEngineConfigurationHandler(
    ILogger<CreatePlaneEngineConfigurationHandler> logger,
    [FromKeyedServices("catalog:planeengineconfiguration")] IRepository<PlaneEngineConfiguration> repository)
    : IRequestHandler<CreatePlaneEngineConfigurationCommand, CreatePlaneEngineConfigurationResponse>
{
    public async Task<CreatePlaneEngineConfigurationResponse> Handle(CreatePlaneEngineConfigurationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeEngineConfiguration = PlaneEngineConfiguration.Create(request.Name);
        await repository.AddAsync(planeEngineConfiguration, cancellationToken);
        logger.LogInformation("plane engine configuration created {PlaneEngineConfigurationId}", planeEngineConfiguration.Id);
        return new CreatePlaneEngineConfigurationResponse(planeEngineConfiguration.Id);
    }
}
