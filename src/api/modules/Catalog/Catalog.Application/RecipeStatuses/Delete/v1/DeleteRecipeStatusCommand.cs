using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Delete.v1;
public sealed record DeleteRecipeStatusCommand(
    Guid Id) : IRequest;
