using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Create.v1;
public sealed class CreatePlaneManufacturerHandler(
    ILogger<CreatePlaneManufacturerHandler> logger,
    [FromKeyedServices("catalog:planemanufacturers")] IRepository<PlaneManufacturer> repository)
    : IRequestHandler<CreatePlaneManufacturerCommand, CreatePlaneManufacturerResponse>
{
    public async Task<CreatePlaneManufacturerResponse> Handle(CreatePlaneManufacturerCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var planeManufacturer = PlaneManufacturer.Create(request.Name);        
        await repository.AddAsync(planeManufacturer, cancellationToken);
        logger.LogInformation("plane manufacturer created {PlaneManufacturerId}", planeManufacturer.Id);
        return new CreatePlaneManufacturerResponse(planeManufacturer.Id);
    }
}
