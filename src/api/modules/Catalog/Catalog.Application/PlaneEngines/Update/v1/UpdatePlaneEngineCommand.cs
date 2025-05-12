using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Update.v1;
public sealed record UpdatePlaneEngineCommand(
    Guid Id,
    string? Name) : IRequest<UpdatePlaneEngineResponse>;
