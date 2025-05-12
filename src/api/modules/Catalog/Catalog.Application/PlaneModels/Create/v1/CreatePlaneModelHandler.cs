using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Create.v1;
public sealed class CreatePlaneModelHandler(
    ILogger<CreatePlaneModelHandler> logger,
    [FromKeyedServices("catalog:planemodels")] IRepository<PlaneModel> repository)
    : IRequestHandler<CreatePlaneModelCommand, CreatePlaneModelResponse>
{
    public async Task<CreatePlaneModelResponse> Handle(CreatePlaneModelCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeModel = PlaneModel.Create(request.Name);
        await repository.AddAsync(planeModel, cancellationToken);
        logger.LogInformation("plane model created {PlaneModelId}", planeModel.Id);
        return new CreatePlaneModelResponse(planeModel.Id);
    }
}
