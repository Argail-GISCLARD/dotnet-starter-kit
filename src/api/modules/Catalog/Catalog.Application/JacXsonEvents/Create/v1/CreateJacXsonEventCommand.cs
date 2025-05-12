using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Create.v1;
public sealed record CreateJacXsonEventCommand(
    [property: DefaultValue("JacXson Serial Number")] string JacXsonSerialNumber,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime OccuredAt,
    [property: DefaultValue("Source")] string? Source = null,
    [property: DefaultValue("Name of the event")] string? EventName = null,
    [property: DefaultValue("Details")] string? Details = null)
    : IRequest<CreateJacXsonEventResponse>;

