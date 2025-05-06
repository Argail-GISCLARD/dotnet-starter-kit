using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Create.v1;
public sealed record CreateRecipeCommand(
    [property: DefaultValue("Sample Recipe")] string? Name) : IRequest<CreateRecipeResponse>;
