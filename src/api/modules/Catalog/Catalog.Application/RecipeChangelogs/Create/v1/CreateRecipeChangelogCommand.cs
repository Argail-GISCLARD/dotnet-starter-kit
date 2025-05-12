using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Create.v1;
public sealed record CreateRecipeChangelogCommand(
    [property: DefaultValue("Content")] string? Content = null,
    [property: DefaultValue("Summary")] string? Summary= null
    )
    : IRequest<CreateRecipeChangelogResponse>;

