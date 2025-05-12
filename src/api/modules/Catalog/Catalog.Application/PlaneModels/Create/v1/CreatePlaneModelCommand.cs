using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Create.v1;
public sealed record CreatePlaneModelCommand(
    [property: DefaultValue("Plane Model Name")] string Name
    )
    : IRequest<CreatePlaneModelResponse>;

