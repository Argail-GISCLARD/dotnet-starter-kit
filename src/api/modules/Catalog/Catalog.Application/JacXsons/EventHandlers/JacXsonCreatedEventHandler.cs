using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.EventHandlers;

public class JacXsonCreatedEventHandler(ILogger<JacXsonCreatedEventHandler> logger) : INotificationHandler<JacXsonCreated>
{
    public async Task Handle(JacXsonCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling jacxson created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling jacxson created domain event..");
    }
}
