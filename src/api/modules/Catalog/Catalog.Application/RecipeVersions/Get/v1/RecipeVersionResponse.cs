namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Get.v1;
public sealed record RecipeVersionResponse(Guid? Id, int VersionNumber, string? Description, bool IsMandatory, DateTime ReleasedOn, DateTime UpdatedOn, string? Publisher);
