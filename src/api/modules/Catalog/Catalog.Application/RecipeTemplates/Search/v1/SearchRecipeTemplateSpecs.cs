using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Search.v1;
public class SearchRecipeTemplateSpecs : EntitiesByPaginationFilterSpec<RecipeTemplate, RecipeTemplateResponse>
{
    public SearchRecipeTemplateSpecs(SearchRecipeTemplatesCommand command)
        : base(command) =>
        Query
            .OrderBy(c => c.VersionNumber, !command.HasOrderBy())
            .Where(b => b.VersionNumber == command.VersionNumber!.Value, command.VersionNumber.HasValue)
            .Where(b => b.Publisher.Contains(command.Publisher), !string.IsNullOrEmpty(command.Publisher));
}
