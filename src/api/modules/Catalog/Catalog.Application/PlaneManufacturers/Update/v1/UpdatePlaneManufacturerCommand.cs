using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Update.v1;
public sealed record UpdatePlaneManufacturerCommand(
    Guid Id,
    string Name) : IRequest<UpdatePlaneManufacturerResponse>;
