using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Delete.v1;
public sealed record DeleteRecipeTemplateContentCommand(
    Guid Id) : IRequest;
