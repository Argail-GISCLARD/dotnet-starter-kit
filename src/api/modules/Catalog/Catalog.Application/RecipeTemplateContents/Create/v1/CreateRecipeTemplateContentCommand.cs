using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Create.v1;
public sealed record CreateRecipeTemplateContentCommand(
    [property: DefaultValue("Recipe Template Content")] string? Content = null)
    : IRequest<CreateRecipeTemplateContentResponse>;

