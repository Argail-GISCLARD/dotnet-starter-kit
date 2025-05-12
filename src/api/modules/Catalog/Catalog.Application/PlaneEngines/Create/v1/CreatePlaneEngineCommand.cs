using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Create.v1;
public sealed record CreatePlaneEngineCommand(
    [property: DefaultValue("Plane Engine Name")] string Name)
    : IRequest<CreatePlaneEngineResponse>;

