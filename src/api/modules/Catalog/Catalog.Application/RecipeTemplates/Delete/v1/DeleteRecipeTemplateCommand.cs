using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Delete.v1;
public sealed record DeleteRecipeTemplateCommand(
    Guid Id) : IRequest;
