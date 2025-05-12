using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Update.v1;
public sealed record UpdateStandCommand(
    Guid Id,
    string? Name) : IRequest<UpdateStandResponse>;
