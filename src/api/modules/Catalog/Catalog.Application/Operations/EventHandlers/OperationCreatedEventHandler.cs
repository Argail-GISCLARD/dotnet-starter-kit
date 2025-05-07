using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.EventHandlers;

public class OperationCreatedEventHandler(ILogger<OperationCreatedEventHandler> logger) : INotificationHandler<OperationCreated>
{
    public async Task Handle(OperationCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling operation created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling operation created domain event..");
    }
}

