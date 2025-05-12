using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.EventHandlers;

public class RecipeChangelogCreatedEventHandler(ILogger<RecipeChangelogCreatedEventHandler> logger) : INotificationHandler<RecipeChangelogCreated>
{
    public async Task Handle(RecipeChangelogCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipe changelog created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipe changelog created domain event..");
    }
}
