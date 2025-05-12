using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Create.v1;
public sealed class CreateJacXsonEventHandler(
    ILogger<CreateJacXsonEventHandler> logger,
    [FromKeyedServices("catalog:jacxsonevents")] IRepository<JacXsonEvent> repository)
    : IRequestHandler<CreateJacXsonEventCommand, CreateJacXsonEventResponse>
{
    public async Task<CreateJacXsonEventResponse> Handle(CreateJacXsonEventCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonEvent = JacXsonEvent.Create(request.JacXsonSerialNumber, request.OccuredAt, request.Source, request.EventName, request.Details);        
        await repository.AddAsync(jacXsonEvent, cancellationToken);
        logger.LogInformation("jacxson event created {JacXsonEventId}", jacXsonEvent.Id);
        return new CreateJacXsonEventResponse(jacXsonEvent.Id);
    }
}
