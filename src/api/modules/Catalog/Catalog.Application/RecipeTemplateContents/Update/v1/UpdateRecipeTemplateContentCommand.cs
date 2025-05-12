using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplateContents.Update.v1;
public sealed record UpdateRecipeTemplateContentCommand(
    Guid Id,
    string? Content = null) : IRequest<UpdateRecipeTemplateContentResponse>;
