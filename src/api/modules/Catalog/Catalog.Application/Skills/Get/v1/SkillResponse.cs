namespace FSH.Starter.WebApi.Catalog.Application.Skills.Get.v1;
public sealed record SkillResponse(Guid? Id, string Name, bool IsPermanent, TimeSpan Duration, string TenantId);
