using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.EventHandlers;

public class PlaneEngineConfigurationCreatedEventHandler(ILogger<PlaneEngineConfigurationCreatedEventHandler> logger) : INotificationHandler<PlaneEngineConfigurationCreated>
{
    public async Task Handle(PlaneEngineConfigurationCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling plane engine configuration created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling plane engine configuration created domain event..");
    }
}
