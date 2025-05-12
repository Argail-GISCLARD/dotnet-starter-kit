using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Delete.v1;
public sealed record DeleteRecipeChangelogCommand(
    Guid Id) : IRequest;
