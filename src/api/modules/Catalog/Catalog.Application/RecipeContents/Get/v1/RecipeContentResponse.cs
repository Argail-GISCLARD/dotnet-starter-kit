namespace FSH.Starter.WebApi.Catalog.Application.RecipeContents.Get.v1;
public sealed record RecipeContentResponse(Guid? Id, string? Content, string? Checksum);
