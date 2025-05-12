using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Create.v1;
public sealed record CreatePlaneManufacturerCommand(
    [property: DefaultValue("Plane Manufacturer Name")] string Name)
    : IRequest<CreatePlaneManufacturerResponse>;

