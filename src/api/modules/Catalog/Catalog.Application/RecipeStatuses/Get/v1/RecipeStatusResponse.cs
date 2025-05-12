namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Get.v1;
public sealed record RecipeStatusResponse(Guid? Id, int Status, DateTime ManufacturerDecisionOn, DateTime ExcentDecisionOn);
