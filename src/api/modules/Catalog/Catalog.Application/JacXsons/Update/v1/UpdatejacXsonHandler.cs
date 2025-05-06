using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Update.v1;
public sealed class UpdateJacXsonHandler(
    ILogger<UpdateJacXsonHandler> logger,
    [FromKeyedServices("catalog:jacxsons")] IRepository<JacXson> repository)
    : IRequestHandler<UpdateJacXsonCommand, UpdateJacXsonResponse>
{
    public async Task<UpdateJacXsonResponse> Handle(UpdateJacXsonCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXson = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXson ?? throw new JacXsonNotFoundException(request.Id);
        var updatedJacXson = jacXson.Update(request.SerialNumber, request.Status, request.W0, request.L, request.Salt);
        await repository.UpdateAsync(updatedJacXson, cancellationToken);
        logger.LogInformation("jacxson with id : {JacXsonId} updated.", jacXson.Id);
        return new UpdateJacXsonResponse(jacXson.Id);
    }
}
