using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.EventHandlers;

public class PlaneModelCreatedEventHandler(ILogger<PlaneModelCreatedEventHandler> logger) : INotificationHandler<PlaneModelCreated>
{
    public async Task Handle(PlaneModelCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling plane model created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling plane model created domain event..");
    }
}
