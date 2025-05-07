using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Update.v1;
public sealed record UpdateRecipeVersionCommand(
    Guid Id,
    int VersionNumber,
    bool IsMandatory,
    DateTime ReleasedOn,
    DateTime UpdatedOn,
    string? Description = null,
    string? Publisher = null) : IRequest<UpdateRecipeVersionResponse>;
