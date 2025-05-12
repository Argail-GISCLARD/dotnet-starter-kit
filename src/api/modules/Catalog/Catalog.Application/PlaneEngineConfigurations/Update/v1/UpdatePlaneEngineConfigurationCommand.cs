using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Update.v1;
public sealed record UpdatePlaneEngineConfigurationCommand(
    Guid Id,
    string Name) : IRequest<UpdatePlaneEngineConfigurationResponse>;
