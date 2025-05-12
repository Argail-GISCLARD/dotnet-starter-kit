using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.EventHandlers;

public class RecipeTemplateContentCreatedEventHandler(ILogger<RecipeTemplateContentCreatedEventHandler> logger) : INotificationHandler<RecipeTemplateContentCreated>
{
    public async Task Handle(RecipeTemplateContentCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling recipe template content created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling recipe template content created domain event..");
    }
}
