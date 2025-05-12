namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Get.v1;
public sealed record JacXsonRecipeVersionResponse(Guid? Id, string? InstalledBy, DateTime InstalledOn, Guid? JacXsonId, Guid? RecipeId);
