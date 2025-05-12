using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Delete.v1;
public sealed record DeletePlaneEngineCommand(
    Guid Id) : IRequest;
