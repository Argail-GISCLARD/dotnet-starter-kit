namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Get.v1;
public sealed record RecipeResponse(Guid? Id, string Name, int Version, string? Content, string? Changelog);
