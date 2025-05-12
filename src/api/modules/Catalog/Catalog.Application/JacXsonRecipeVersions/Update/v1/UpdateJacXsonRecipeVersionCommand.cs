using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Update.v1;
public sealed record UpdateJacXsonRecipeVersionCommand(
    Guid Id,
    string InstalledBy,
    DateTime InstalledOn,
    Guid? RecipeId = null,
    Guid? JacXsonId = null) : IRequest<UpdateJacXsonRecipeVersionResponse>;
