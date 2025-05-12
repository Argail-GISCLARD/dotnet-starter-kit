using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Delete.v1;
public sealed record DeleteStandCommand(
    Guid Id) : IRequest;
