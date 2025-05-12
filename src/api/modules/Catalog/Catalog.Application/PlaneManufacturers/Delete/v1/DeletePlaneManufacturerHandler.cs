using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Delete.v1;
public sealed class DeletePlaneManufacturerHandler(
    ILogger<DeletePlaneManufacturerHandler> logger,
    [FromKeyedServices("catalog:planemanufacturers")] IRepository<PlaneManufacturer> repository)
    : IRequestHandler<DeletePlaneManufacturerCommand>
{
    public async Task Handle(DeletePlaneManufacturerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var PlaneManufacturer = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = PlaneManufacturer ?? throw new PlaneManufacturerNotFoundException(request.Id);
        await repository.DeleteAsync(PlaneManufacturer, cancellationToken);
        logger.LogInformation("plane manufacturer with id : {PlaneManufacturerId} deleted", PlaneManufacturer.Id);
    }
}
