using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Delete.v1;
public sealed record DeletePlaneManufacturerCommand(
    Guid Id) : IRequest;
