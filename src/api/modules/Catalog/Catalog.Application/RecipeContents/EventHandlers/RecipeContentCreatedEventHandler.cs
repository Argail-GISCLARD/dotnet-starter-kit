using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.EventHandlers;

public class RecipeContentCreatedEventHandler(ILogger<RecipeContentCreatedEventHandler> logger) : INotificationHandler<RecipeContentCreated>
{
    public async Task Handle(RecipeContentCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipe content created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipe content created domain event..");
    }
}
