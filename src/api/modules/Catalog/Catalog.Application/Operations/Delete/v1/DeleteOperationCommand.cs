using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Delete.v1;
public sealed record DeleteOperationCommand(
    Guid Id) : IRequest;
