using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Update.v1;
public sealed class UpdateJacXsonEventHandler(
    ILogger<UpdateJacXsonEventHandler> logger,
    [FromKeyedServices("catalog:jacxsonevents")] IRepository<JacXsonEvent> repository)
    : IRequestHandler<UpdateJacXsonEventCommand, UpdateJacXsonEventResponse>
{
    public async Task<UpdateJacXsonEventResponse> Handle(UpdateJacXsonEventCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonEvent = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXsonEvent ?? throw new JacXsonEventNotFoundException(request.Id);
        var updatedJacXsonEvent = jacXsonEvent.Update(request.JacXsonSerialNumber, request.OccuredAt, request.Source, request.EventName, request.Details);
        await repository.UpdateAsync(updatedJacXsonEvent, cancellationToken);
        logger.LogInformation("jacxson event with id : {JacXsonEventId} updated.", jacXsonEvent.Id);
        return new UpdateJacXsonEventResponse(jacXsonEvent.Id);
    }
}
