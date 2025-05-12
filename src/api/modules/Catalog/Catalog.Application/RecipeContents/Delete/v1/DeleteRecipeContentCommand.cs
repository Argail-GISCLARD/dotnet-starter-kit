using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Delete.v1;
public sealed record DeleteRecipeContentCommand(
    Guid Id) : IRequest;
