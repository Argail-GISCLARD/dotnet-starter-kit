using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.EventHandlers;

public class StandCreatedEventHandler(ILogger<StandCreatedEventHandler> logger) : INotificationHandler<StandCreated>
{
    public async Task Handle(StandCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling stand created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling stand created domain event..");
    }
}
