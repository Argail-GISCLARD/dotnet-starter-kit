using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Delete.v1;
public sealed record DeleteJacXsonCommand(
    Guid Id) : IRequest;
