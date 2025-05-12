using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Create.v1;
public sealed record CreateRecipeTemplateCommand(
    [property: DefaultValue(0)] int VersionNumber,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime ReleasedOn,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime UpdatedOn,
    [property: DefaultValue(false)] bool IsMandatory,
    [property: DefaultValue(false)] bool IsPaid,
    [property: DefaultValue("Publisher")] string? Publisher = null,
    [property: DefaultValue("Descriptive Description")] string? Description = null,
    [property: DefaultValue(null)] Guid? RecipeTemplateContentId = null)
    : IRequest<CreateRecipeTemplateResponse>;

