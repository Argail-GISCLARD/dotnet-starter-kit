using System.ComponentModel;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Create.v1;
public sealed record CreateRecipeVersionCommand(
    [property: DefaultValue(0)] int VersionNumber,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime ReleasedOn,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime UpdatedOn,
    [property: DefaultValue(false)] bool IsMandatory, 
    [property: DefaultValue("Publisher")] string? Publisher = null,
    [property: DefaultValue("Descriptive Description")] string? Description = null)
    : IRequest<CreateRecipeVersionResponse>;

