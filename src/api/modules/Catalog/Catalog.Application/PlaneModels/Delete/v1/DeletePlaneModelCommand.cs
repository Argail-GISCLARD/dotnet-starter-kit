using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Delete.v1;
public sealed record DeletePlaneModelCommand(
    Guid Id) : IRequest;
