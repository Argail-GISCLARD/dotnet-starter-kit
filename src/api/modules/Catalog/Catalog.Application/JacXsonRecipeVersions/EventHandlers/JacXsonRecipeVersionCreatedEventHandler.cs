using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.EventHandlers;

public class JacXsonRecipeVersionCreatedEventHandler(ILogger<JacXsonRecipeVersionCreatedEventHandler> logger) : INotificationHandler<JacXsonRecipeVersionCreated>
{
    public async Task Handle(JacXsonRecipeVersionCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling jacxson recipe version created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling jacxson recipe version created domain event..");
    }
}
