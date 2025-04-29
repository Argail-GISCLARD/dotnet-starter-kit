using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.EventHandlers;

public class RecipeCreatedEventHandler(ILogger<RecipeCreatedEventHandler> logger) : INotificationHandler<RecipeCreated>
{
    public async Task Handle(RecipeCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipe created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipe created domain event..");
    }
}

