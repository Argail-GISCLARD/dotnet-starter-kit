using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Create.v1;
public sealed record CreateRecipeContentCommand(
    [property: DefaultValue("Content")] string? Content = null,
    [property: DefaultValue("Checksum")] string? Checksum = null
    )
    : IRequest<CreateRecipeContentResponse>;

