using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Update.v1;
public sealed record UpdatePlaneModelCommand(
    Guid Id,
    string Name) : IRequest<UpdatePlaneModelResponse>;
