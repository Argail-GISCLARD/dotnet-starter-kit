using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Create.v1;
public sealed record CreatePlaneEngineConfigurationCommand(
    [property: DefaultValue(0)] int VersionNumber,
    [property: DefaultValue("Plane engine configuration name")] string Name)
    : IRequest<CreatePlaneEngineConfigurationResponse>;

