using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Delete.v1;
public sealed class DeletePlaneModelHandler(
    ILogger<DeletePlaneModelHandler> logger,
    [FromKeyedServices("catalog:planemodels")] IRepository<PlaneModel> repository)
    : IRequestHandler<DeletePlaneModelCommand>
{
    public async Task Handle(DeletePlaneModelCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeModel = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = planeModel ?? throw new PlaneModelNotFoundException(request.Id);
        await repository.DeleteAsync(planeModel, cancellationToken);
        logger.LogInformation("plane model with id : {PlaneModelId} deleted", planeModel.Id);
    }
}
