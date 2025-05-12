using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Delete.v1;
public sealed record DeletePlaneEngineConfigurationCommand(
    Guid Id) : IRequest;
