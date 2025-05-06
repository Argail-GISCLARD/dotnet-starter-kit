using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Update.v1;
public sealed record UpdateRecipeCommand(
    Guid Id,
    string? Name) : IRequest<UpdateRecipeResponse>;
