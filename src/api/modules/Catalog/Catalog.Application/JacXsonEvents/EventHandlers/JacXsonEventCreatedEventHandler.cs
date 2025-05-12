using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.EventHandlers;

public class JacXsonEventCreatedEventHandler(ILogger<JacXsonEventCreatedEventHandler> logger) : INotificationHandler<JacXsonEventCreated>
{
    public async Task Handle(JacXsonEventCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling jacxson event created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling jacxson event created domain event..");
    }
}
