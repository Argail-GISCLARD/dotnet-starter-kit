using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.EventHandlers;

public class PlaneEngineCreatedEventHandler(ILogger<PlaneEngineCreatedEventHandler> logger) : INotificationHandler<PlaneEngineCreated>
{
    public async Task Handle(PlaneEngineCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling plane engine created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling plane engine created domain event..");
    }
}
