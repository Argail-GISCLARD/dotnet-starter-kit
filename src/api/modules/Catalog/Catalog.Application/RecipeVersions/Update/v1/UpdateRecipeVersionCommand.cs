using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Update.v1;
public sealed record UpdateRecipeVersionCommand(
    Guid Id,
    int VersionNumber,
    bool IsMandatory,
    bool IsPaid,
    DateTime ReleasedOn,
    DateTime UpdatedOn,
    string? Description = null,
    string? Publisher = null,
    Collection<Operation>? Operations = null,
    Collection<JacXsonRecipeVersion>? JacXsonRecipeVersions = null,
    Collection<Skill>? Skills = null,
    Guid? RecipeId = null,
    Guid? JacXsonTypeId = null,
    Guid? RecipeStatusId = null,
    Guid? RecipeContentId = null,
    Guid? RecipeChangelogId = null,
    Recipe Recipe = default!,
    JacXsonType JacXsonType = default!,
    RecipeStatus RecipeStatus = default!,
    RecipeContent RecipeContent = default!,
    RecipeChangelog RecipeChangelog = default!) : IRequest<UpdateRecipeVersionResponse>;
