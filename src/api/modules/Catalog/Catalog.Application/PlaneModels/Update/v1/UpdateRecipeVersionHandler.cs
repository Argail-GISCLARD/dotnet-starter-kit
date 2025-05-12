using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Update.v1;
public sealed class UpdatePlaneModelHandler(
    ILogger<UpdatePlaneModelHandler> logger,
    [FromKeyedServices("catalog:planemodels")] IRepository<PlaneModel> repository)
    : IRequestHandler<UpdatePlaneModelCommand, UpdatePlaneModelResponse>
{
    public async Task<UpdatePlaneModelResponse> Handle(UpdatePlaneModelCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeModel = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = planeModel ?? throw new PlaneModelNotFoundException(request.Id);
        var updatedPlaneModel = planeModel.Update(request.Name);
        await repository.UpdateAsync(updatedPlaneModel, cancellationToken);
        logger.LogInformation("plane model with id : {PlaneModelId} updated.", planeModel.Id);
        return new UpdatePlaneModelResponse(planeModel.Id);
    }
}
