using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.EventHandlers;

public class RecipeStatusCreatedEventHandler(ILogger<RecipeStatusCreatedEventHandler> logger) : INotificationHandler<RecipeStatusCreated>
{
    public async Task Handle(RecipeStatusCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipe status created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipe status created domain event..");
    }
}
