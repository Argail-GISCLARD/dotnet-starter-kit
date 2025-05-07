using System.Collections.ObjectModel;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
public sealed record OperationResponse(Guid? Id, string? Name, Collection<RecipeVersion>? RecipeVersions);
