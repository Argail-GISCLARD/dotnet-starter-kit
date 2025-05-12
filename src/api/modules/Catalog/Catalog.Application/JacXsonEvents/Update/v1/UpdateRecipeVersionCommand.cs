using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Update.v1;
public sealed record UpdateJacXsonEventCommand(
    Guid Id,
    string JacXsonSerialNumber,
    DateTime OccuredAt,
    string? Source = null,
    string? EventName = null,
    string? Details = null) : IRequest<UpdateJacXsonEventResponse>;
