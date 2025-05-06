using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.EventHandlers;

public class RecipeVersionCreatedEventHandler(ILogger<RecipeVersionCreatedEventHandler> logger) : INotificationHandler<RecipeVersionCreated>
{
    public async Task Handle(RecipeVersionCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipeVersion created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipeVersion created domain event..");
    }
}
