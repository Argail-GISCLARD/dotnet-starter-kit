using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.EventHandlers;

public class RecipeTemplateCreatedEventHandler(ILogger<RecipeTemplateCreatedEventHandler> logger) : INotificationHandler<RecipeTemplateCreated>
{
    public async Task Handle(RecipeTemplateCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipe template created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipe template created domain event..");
    }
}
