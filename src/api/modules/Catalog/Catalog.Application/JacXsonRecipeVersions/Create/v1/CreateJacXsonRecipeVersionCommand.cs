using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Create.v1;
public sealed record CreateJacXsonRecipeVersionCommand(
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime InstalledOn,
    [property: DefaultValue("Publisher")] string? InstalledBy = null,
    [property: DefaultValue(null)] Guid? JacXsonId = null,
    [property: DefaultValue(null)] Guid? RecipeId = null)
    : IRequest<CreateJacXsonRecipeVersionResponse>;

