using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Create.v1;
public sealed record CreateRecipeVersionCommand(
    [property: DefaultValue(0)] int VersionNumber,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime ReleasedOn,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime UpdatedOn,
    [property: DefaultValue(false)] bool IsMandatory,
    [property: DefaultValue(false)] bool IsPaid,
    [property: DefaultValue("Publisher")] string? Publisher = null,
    [property: DefaultValue("Descriptive Description")] string? Description = null,
    [property: DefaultValue(null)] Guid? RecipeId = null,
    [property: DefaultValue(null)] Guid? JacXsonTypeId = null,
    [property: DefaultValue(null)] Guid? RecipeStatusId= null,
    [property: DefaultValue(null)] Guid? RecipeContentId = null,
    [property: DefaultValue(null)] Guid? RecipeChangelogId = null,
    [property: DefaultValue(null)] Recipe Recipe = default!,
    [property: DefaultValue(null)] JacXsonType JacXsonType = default!,
    [property: DefaultValue(null)] RecipeStatus RecipeStatus = default!,
    [property: DefaultValue(null)] RecipeContent RecipeContent = default!,
    [property: DefaultValue(null)] RecipeChangelog RecipeChangelog = default!
    )
    : IRequest<CreateRecipeVersionResponse>;

