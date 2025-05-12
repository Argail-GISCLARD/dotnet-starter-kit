using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Update.v1;
public sealed record UpdateRecipeContentCommand(
    Guid Id,
    string? Content = null,
    string? Checksum = null) : IRequest<UpdateRecipeContentResponse>;
