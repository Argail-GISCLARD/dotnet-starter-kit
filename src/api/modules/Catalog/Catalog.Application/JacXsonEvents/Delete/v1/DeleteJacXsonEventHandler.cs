using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Delete.v1;
public sealed class DeleteJacXsonEventHandler(
    ILogger<DeleteJacXsonEventHandler> logger,
    [FromKeyedServices("catalog:jacxsonevents")] IRepository<JacXsonEvent> repository)
    : IRequestHandler<DeleteJacXsonEventCommand>
{
    public async Task Handle(DeleteJacXsonEventCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonEvent = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXsonEvent ?? throw new JacXsonEventNotFoundException(request.Id);
        await repository.DeleteAsync(jacXsonEvent, cancellationToken);
        logger.LogInformation("jacxson event with id : {JacXsonEventId} deleted", jacXsonEvent.Id);
    }
}
