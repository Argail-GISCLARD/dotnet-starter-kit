using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.EventHandlers;

public class JacXsonTypeCreatedEventHandler(ILogger<JacXsonTypeCreatedEventHandler> logger) : INotificationHandler<JacXsonTypeCreated>
{
    public async Task Handle(JacXsonTypeCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling jacxson type created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling jacxson type created domain event..");
    }
}
