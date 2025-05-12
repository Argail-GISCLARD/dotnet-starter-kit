using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.EventHandlers;

public class SkillCreatedEventHandler(ILogger<SkillCreatedEventHandler> logger) : INotificationHandler<SkillCreated>
{
    public async Task Handle(SkillCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling skill created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling skill created domain event..");
    }
}
