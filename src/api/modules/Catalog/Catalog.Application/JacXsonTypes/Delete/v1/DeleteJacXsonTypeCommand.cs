using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Delete.v1;
public sealed record DeleteJacXsonTypeCommand(
    Guid Id) : IRequest;
