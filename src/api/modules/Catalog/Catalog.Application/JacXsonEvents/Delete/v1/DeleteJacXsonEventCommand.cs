using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Delete.v1;
public sealed record DeleteJacXsonEventCommand(
    Guid Id) : IRequest;
