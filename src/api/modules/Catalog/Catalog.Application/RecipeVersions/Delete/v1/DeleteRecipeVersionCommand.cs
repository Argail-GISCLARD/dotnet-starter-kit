using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Delete.v1;
public sealed record DeleteRecipeVersionCommand(
    Guid Id) : IRequest;
