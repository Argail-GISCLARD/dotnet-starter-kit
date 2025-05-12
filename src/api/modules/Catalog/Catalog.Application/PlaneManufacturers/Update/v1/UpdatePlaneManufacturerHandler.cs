using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Update.v1;
public sealed class UpdatePlaneManufacturerHandler(
    ILogger<UpdatePlaneManufacturerHandler> logger,
    [FromKeyedServices("catalog:planemanufacturers")] IRepository<PlaneManufacturer> repository)
    : IRequestHandler<UpdatePlaneManufacturerCommand, UpdatePlaneManufacturerResponse>
{
    public async Task<UpdatePlaneManufacturerResponse> Handle(UpdatePlaneManufacturerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeManufacturer = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = planeManufacturer ?? throw new PlaneManufacturerNotFoundException(request.Id);
        var updatedPlaneManufacturer = planeManufacturer.Update(request.Name);
        await repository.UpdateAsync(updatedPlaneManufacturer, cancellationToken);
        logger.LogInformation("plane mafunacturer with id : {PlaneManufacturerId} updated.", planeManufacturer.Id);
        return new UpdatePlaneManufacturerResponse(planeManufacturer.Id);
    }
}
