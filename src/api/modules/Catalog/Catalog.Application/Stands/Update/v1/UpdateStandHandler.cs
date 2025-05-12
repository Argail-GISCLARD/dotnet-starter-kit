using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Update.v1;
public sealed class UpdateStandHandler(
    ILogger<UpdateStandHandler> logger,
    [FromKeyedServices("catalog:stands")] IRepository<Stand> repository)
    : IRequestHandler<UpdateStandCommand, UpdateStandResponse>
{
    public async Task<UpdateStandResponse> Handle(UpdateStandCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var stand = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = stand ?? throw new StandNotFoundException(request.Id);
        var updatedStand = stand.Update(request.Name);
        await repository.UpdateAsync(updatedStand, cancellationToken);
        logger.LogInformation("stand with id : {StandId} updated.", stand.Id);
        return new UpdateStandResponse(stand.Id);
    }
}
