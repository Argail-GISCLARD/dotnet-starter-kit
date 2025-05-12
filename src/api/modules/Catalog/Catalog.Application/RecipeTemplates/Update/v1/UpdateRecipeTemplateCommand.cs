using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Update.v1;
public sealed record UpdateRecipeTemplateCommand(
    Guid Id,
    int VersionNumber,
    bool IsMandatory,
    bool IsPaid,
    DateTime ReleasedOn,
    DateTime UpdatedOn,
    string? Description = null,
    string? Publisher = null,
    Guid? RecipeTemplateContentId = null) : IRequest<UpdateRecipeTemplateResponse>;
