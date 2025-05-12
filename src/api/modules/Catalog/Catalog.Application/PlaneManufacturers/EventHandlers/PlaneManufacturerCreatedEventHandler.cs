using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.EventHandlers;

public class PlaneManufacturerCreatedEventHandler(ILogger<PlaneManufacturerCreatedEventHandler> logger) : INotificationHandler<PlaneManufacturerCreated>
{
    public async Task Handle(PlaneManufacturerCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling plane manufacturer created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling plane manufacturer created domain event..");
    }
}
