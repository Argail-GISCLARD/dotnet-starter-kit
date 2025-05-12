using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Delete.v1;
public sealed record DeleteJacXsonRecipeVersionCommand(
    Guid Id) : IRequest;
