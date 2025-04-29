using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Create.v1;
public sealed record CreateRecipeCommand(
    [property: DefaultValue("Sample Recipe")] string? Name,
    [property: DefaultValue(0)] int Version,
    [property: DefaultValue("Content")] string? Content = null,
    [property: DefaultValue("Changes")] string? Changelog = null) : IRequest<CreateRecipeResponse>;
