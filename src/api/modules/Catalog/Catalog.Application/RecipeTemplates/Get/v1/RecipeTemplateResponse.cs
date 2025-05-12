namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Get.v1;
public sealed record RecipeTemplateResponse(Guid? Id, int VersionNumber, string? Description, bool IsMandatory, DateTime ReleasedOn, DateTime UpdatedOn, string? Publisher, Guid? RecipeTemplateContentId);
