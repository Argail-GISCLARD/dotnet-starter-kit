using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Delete.v1;
public sealed record DeleteRecipeCommand(
    Guid Id) : IRequest;
